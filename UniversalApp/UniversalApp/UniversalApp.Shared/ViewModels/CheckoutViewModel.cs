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
    public class CheckoutViewModel : ViewModelBase
    {
        #region Declarations
        /////////////////////////////////////////////////////////////////
        private readonly IDialogService _dialogService;

        /////////////////////////////////////////////////////////////////
        #endregion

        #region Properties
        /////////////////////////////////////////////////////////////////
        public ObservableCollection<CheckoutsLines> Cart { get; set; }

        public double CartTotal
        {
            get { return Cart.Sum(c => c.Quantity * c.ProductPrice); }
        }
        /////////////////////////////////////////////////////////////////
        #endregion

        #region Constructor
        /////////////////////////////////////////////////////////////////
        public CheckoutViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        /////////////////////////////////////////////////////////////////
        #endregion

        #region Commands
        /////////////////////////////////////////////////////////////////

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand
        {
            get { return _backCommand = _backCommand ?? new DelegateCommand(BackCommandDelegate, CanBackCommandDelegate); }
        }
        public bool CanBackCommandDelegate()
        {
            return !IsBusy;
        }
        public void BackCommandDelegate()
        {
            NavigationService.NavigateToPage(ViewsEnum.MainPage);
        }

        private DelegateCommand _checkoutCommand;
        public DelegateCommand CheckoutCommand
        {
            get { return _checkoutCommand = _checkoutCommand ?? new DelegateCommand(CheckoutCommandDelegate, CanCheckoutCommandDelegate); }
        }
        public bool CanCheckoutCommandDelegate()
        {
            return !IsBusy;
        }
        public void CheckoutCommandDelegate()
        {
            Checkout(Cart);
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
            if (args.Parameter != null && args.Parameter is ObservableCollection<CheckoutsLines>)
            {
                Cart = (ObservableCollection<CheckoutsLines>)args.Parameter;
            }

            return null;
        }

        public override void EnableDisableControls(bool enabled = true)
        {
            CheckoutCommand.RaiseCanExecuteChanged();
            BackCommand.RaiseCanExecuteChanged();
        }

        private async void Checkout(ObservableCollection<CheckoutsLines> CheckoutLines)
        {
            ProgressBarONOFF();

            try
            {
                Checkouts checkout = new Checkouts() { Status = (int)CheckoutStatus.NotPayed, UserId = Globals.CurrentUser.Id };

                await App.MobileService.GetTable<Checkouts>().InsertAsync(checkout);

                foreach (var line in CheckoutLines)
                {
                    line.CheckoutId = checkout.Id;

                    while (line.Quantity > 0)
                    {
                        line.Quantity--;
                        line.Id = Guid.Empty;
                        await App.MobileService.GetTable<CheckoutsLines>().InsertAsync(line);
                    }
                }

                Globals.CurrentCart.Clear();

                ProgressBarONOFF(false);

                await _dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.CheckoutCompleted);
                NavigationService.NavigateToPage(ViewsEnum.MainPage);
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