using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UniversalApp.Model;
using UniversalApp.Services.Dialogs;
using UniversalApp.Services.Navigation;
using UniversalApp.Strings;
using UniversalApp.ViewModels.Base;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Declarations
        /////////////////////////////////////////////////////////////////
        private const int ItemsPerPage = 10;
        private int _currentPage;

        private readonly IDialogService _dialogService;

        public delegate void LoadedRequestAction();
        public event LoadedRequestAction LoadedRequest;
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

        public ObservableCollection<CheckoutsLines> CurrentCart
        {
            get { return Globals.CurrentCart; }
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

        private CheckoutsLines _selectedCartItem;
        public CheckoutsLines SelectedCartItem
        {
            get { return _selectedCartItem; }
            set
            {
                if (value != _selectedCartItem)
                {
                    _selectedCartItem = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double CartTotal
        {
            get { return Globals.CurrentCart.Sum(c => c.Quantity * c.ProductPrice); }
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
            if (SelectedProduct == null)
                return;

            var alreadyIn = CurrentCart.FirstOrDefault(c => c.ProductId == SelectedProduct.Id);
            if (alreadyIn != null)
                alreadyIn.Quantity++;
            else
                CurrentCart.Add(new CheckoutsLines()
                {
                    ProductId = SelectedProduct.Id,
                    ProductPrice = SelectedProduct.Price,
                    Quantity = 1,
                    ProductSmallPicture = SelectedProduct.SmallPicture,
                    ProductName = SelectedProduct.Name
                });

            RaisePropertyChanged("CartTotal");
            CheckoutCommand.RaiseCanExecuteChanged();

            IsDetailVisible = false;
        }

        private DelegateCommand _removeCartCommand;
        public DelegateCommand RemoveCartCommand
        {
            get { return _removeCartCommand = _removeCartCommand ?? new DelegateCommand(RemoveCartCommandDelegate); }
        }
        public void RemoveCartCommandDelegate()
        {
            if (SelectedCartItem == null)
                return;

            if (SelectedCartItem.Quantity > 1)
                SelectedCartItem.Quantity--;
            else
                CurrentCart.Remove(SelectedCartItem);

            RaisePropertyChanged("CartTotal");
            CheckoutCommand.RaiseCanExecuteChanged();
        }

        private DelegateCommand _checkoutCommand;
        public DelegateCommand CheckoutCommand
        {
            get { return _checkoutCommand = _checkoutCommand ?? new DelegateCommand(CheckoutCommandDelegate, CanCheckoutCommandDelegate); }
        }
        public bool CanCheckoutCommandDelegate()
        {
            return CurrentCart.Any();
        }
        public void CheckoutCommandDelegate()
        {
            if (Globals.CurrentUser != null)
                NavigationService.NavigateToPage(ViewsEnum.CheckoutView, CurrentCart);
            else
                _dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorUserNorLoged);
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

            LoadProducts();
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

        public async void LoadProducts(int page = 0)
        {
            ProgressBarONOFF();

            try
            {
                var atribsList = await App.MobileService.GetTable<Products>().Skip(ItemsPerPage * page).Take(ItemsPerPage).ToCollectionAsync();

                if (atribsList.Count > 0)
                    foreach (Products p in atribsList)
                        _collectionProducts.Add(p);
                else
                    _currentPage = _currentPage > 0 ? _currentPage - 1 : 0; //no more pages, so return _currentPage to previous state

                ProgressBarONOFF(false);

                LoadedRequest();
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

        public async Task LoadProductsNextPage()
        {
            if (!IsBusy)
            {
                _currentPage++;
                LoadProducts(_currentPage);
            }
        }
        /////////////////////////////////////////////////////////////////
        #endregion
    }
}
