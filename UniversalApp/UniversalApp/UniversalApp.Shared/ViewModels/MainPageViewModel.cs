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

        private List<Products> _collectionProducts = new List<Products>();
        public List<Products> CollectionProducts
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

        public string CurrentUserText
        {
            get { return Globals.CurrentUser != null ? Globals.CurrentUser.FirstName : Cadenas.NotLogged; }
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
            //LoginCommand.RaiseCanExecuteChanged();
            //RaisePropertyChanged("CurrentUserText");

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

                if (atribTax != null)
                    Globals.TaxPercentage = float.Parse(atribTax.Value);

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

        private async void LoadProducts()
        {
            ProgressBarONOFF();

            try
            {
                var atribsList = await App.MobileService.GetTable<Products>().Skip(ItemsPerPage* _currentPage).Take(ItemsPerPage).ToListAsync();

                CollectionProducts.AddRange(atribsList);
                RaisePropertyChanged("CollectionProducts");

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
