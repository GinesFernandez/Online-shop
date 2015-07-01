using System.Threading.Tasks;
using System.Linq;
using UniversalApp.Services.Dialogs;
using UniversalApp.Services.Navigation;
using UniversalApp.ViewModels.Base;
using Windows.UI.Xaml.Navigation;
using UniversalApp.Strings;
using System;
using Microsoft.WindowsAzure.MobileServices;
using UniversalApp.Model;
using UniversalApp.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UniversalApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Declarations
        /////////////////////////////////////////////////////////////////
        private const int ItemsPerPage = 10;

        private int _currentPage;

        private readonly IDialogService _dialogService;

        /////////////////////////////////////////////////////////////////
        #endregion

        #region Properties
        /////////////////////////////////////////////////////////////////

        public bool Logged
        {
            get { return Globals.CurrentUser != null; }
        }

        public string CurrentUserText
        {
            get { return Globals.CurrentUser != null ? Globals.CurrentUser.FirstName : Cadenas.NotLogged; }
        }

        private ObservableCollection<Products> _collectionProducts = new ObservableCollection<Products>();
        public ObservableCollection<Products> CollectionProducts
        {
            get { return _collectionProducts; }
            set
            {
                if (value != _collectionProducts)
                {
                    _collectionProducts = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<CheckoutsLines> _currentCart = new ObservableCollection<CheckoutsLines>();
        public ObservableCollection<CheckoutsLines> CurrentCart
        {
            get { return _currentCart; }
            set
            {
                if (value != _currentCart)
                {
                    _currentCart = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Products _selectedProduct;
        public Products SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (value != _selectedProduct)
                {
                    _selectedProduct = value;
                    RaisePropertyChanged();
                    PreviousDetailCommand.RaiseCanExecuteChanged();
                    NextDetailCommand.RaiseCanExecuteChanged();

                    IsDetailVisible = true;
                }
            }
        }

        private bool _isDetailVisible;
        public bool IsDetailVisible
        {
            get { return _isDetailVisible; }
            set
            {
                if (value != _isDetailVisible)
                {
                    _isDetailVisible = value;
                    RaisePropertyChanged();
                }
            }
        }

        /////////////////////////////////////////////////////////////////
        #endregion

        #region Constructor
        /////////////////////////////////////////////////////////////////
        public MainPageViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        /////////////////////////////////////////////////////////////////
        #endregion

        #region Commands
        /////////////////////////////////////////////////////////////////
        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new DelegateCommand(LoginCommandDelegate, CanLoginCommandDelegate); }
        }
        public bool CanLoginCommandDelegate()
        {
            return true;
        }
        public void LoginCommandDelegate()
        {
            NavigationService.NavigateToPage(ViewsEnum.LoginView, Globals.CurrentUser);
        }

        private DelegateCommand _closeDetailCommand;
        public DelegateCommand CloseDetailCommand
        {
            get { return _closeDetailCommand = _closeDetailCommand ?? new DelegateCommand(CloseDetailCommandDelegate); }
        }
        public void CloseDetailCommandDelegate()
        {
            IsDetailVisible = false;
        }

        private DelegateCommand _nextDetailCommand;
        public DelegateCommand NextDetailCommand
        {
            get { return _nextDetailCommand = _nextDetailCommand ?? new DelegateCommand(NextDetailCommandDelegate, CanNextDetailCommandDelegate); }
        }
        public bool CanNextDetailCommandDelegate()
        {
            return CollectionProducts.Count > CollectionProducts.IndexOf(SelectedProduct) + 1;
        }
        public void NextDetailCommandDelegate()
        {
            var nextIndex = CollectionProducts.IndexOf(SelectedProduct) + 1;
            if (CollectionProducts.Count > nextIndex)
            {
                SelectedProduct = CollectionProducts[nextIndex];
            }
        }
        private DelegateCommand _previousDetailCommand;
        public DelegateCommand PreviousDetailCommand
        {
            get { return _previousDetailCommand = _previousDetailCommand ?? new DelegateCommand(PreviousDetailCommandDelegate, CanPreviousDetailCommandDelegate); }
        }
        public bool CanPreviousDetailCommandDelegate()
        {
            return CollectionProducts.IndexOf(SelectedProduct) - 1 >= 0;
        }
        public void PreviousDetailCommandDelegate()
        {
            var prevIndex = CollectionProducts.IndexOf(SelectedProduct) - 1;
            if (prevIndex >= 0)
            {
                SelectedProduct = CollectionProducts[prevIndex];
            }
        }

        private DelegateCommand _addToCartCommand;
        public DelegateCommand AddToCartCommand
        {
            get { return _addToCartCommand = _addToCartCommand ?? new DelegateCommand(AddToCartCommandDelegate); }
        }
        public void AddToCartCommandDelegate()
        {
            CurrentCart.Add(new CheckoutsLines() { ProductId = SelectedProduct.Id, Product = SelectedProduct });
            IsDetailVisible = false;
        }
        /////////////////////////////////////////////////////////////////
        #endregion

        #region Methods
        /////////////////////////////////////////////////////////////////
        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            RaisePropertyChanged("CurrentUserText");

            if (!Globals.ResourcesLoaded)
                LoadResources();

            LoadProducts(_currentPage);
            return null;
        }

        public override void EnableDisableControls(bool enabled = true)
        {
        }

        /// <summary>
        /// Load System Configuation
        /// </summary>
        private async void LoadResources()
        {
            ProgressBarONOFF();

            try
            {
                var atribsList = await App.MobileService.GetTable<ApplicationAttributes>().Where(a => a.Value != null).ToListAsync();

                var atribTax = atribsList.FirstOrDefault(a => a.Id == ConstApplicationAttributes.TaxPercentage);
                var atribCurrency = atribsList.FirstOrDefault(a => a.Id == ConstApplicationAttributes.Currency);

                if (atribTax != null)
                    Globals.TaxPercentage = float.Parse(atribTax.Value);
                if (atribCurrency != null)
                    Globals.Currency = atribCurrency.Value;

                Globals.ResourcesLoaded = true;
                ProgressBarONOFF(false);
            }
            catch (MobileServiceInvalidOperationException azureExc)
            {
                ProgressBarONOFF(false);
                IDialogService dialogService = new DialogService();
                var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorConnection);
            }
            catch (FormatException formatExc)
            {
                ProgressBarONOFF(false);
                IDialogService dialogService = new DialogService();
                var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorAttributeFormat);
            }
            catch (Exception exc)
            {
                ProgressBarONOFF(false);
                IDialogService dialogService = new DialogService();
                var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, exc.Message);
            }
        }

        private async void LoadProducts(int page = 0)
        {
            ProgressBarONOFF();

            try
            {
                var atribsList = await App.MobileService.GetTable<Products>().Skip(ItemsPerPage * page).Take(ItemsPerPage).ToCollectionAsync();

                foreach (Products p in atribsList)
                    _collectionProducts.Add(p);

                ProgressBarONOFF(false);
            }
            catch (MobileServiceInvalidOperationException azureExc)
            {
                ProgressBarONOFF(false);
                IDialogService dialogService = new DialogService();
                var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorConnection);
            }
            catch (Exception exc)
            {
                ProgressBarONOFF(false);
                IDialogService dialogService = new DialogService();
                var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, exc.Message);
            }
        }

        /////////////////////////////////////////////////////////////////
        #endregion
    }
}
