using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using UniversalApp.Model;
using UniversalApp.Services.Dialogs;
using UniversalApp.Services.Navigation;
using UniversalApp.Strings;
using UniversalApp.ViewModels.Base;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Declarations
        /////////////////////////////////////////////////////////////////
        private readonly IDialogService _dialogService;

        /////////////////////////////////////////////////////////////////
        #endregion

        #region Properties
        /////////////////////////////////////////////////////////////////

        private bool _isRegistering;
        public bool IsRegistering
        {
            get { return _isRegistering; }
            set
            {
                if (value != _isRegistering)
                {
                    _isRegistering = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsRegisteringValid
        {
            get
            {
                return true; //TODO:
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    RaisePropertyChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    RaisePropertyChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /////////////////////////////////////////////////////////////////
        #endregion

        #region Constructor
        /////////////////////////////////////////////////////////////////
        public LoginViewModel(IDialogService dialogService)
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
            if (!IsBusy)
                NavigationService.NavigateToPage(ViewsEnum.MainPage);
        }

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new DelegateCommand(LoginCommandDelegate, CanLoginCommandDelegate); }
        }
        public bool CanLoginCommandDelegate()
        {
            return !String.IsNullOrWhiteSpace(Password) && !String.IsNullOrWhiteSpace(Name);
        }
        public void LoginCommandDelegate()
        {
            //NavigationService.NavigateToPage(ViewsEnum.MainPageView);
        }

        private DelegateCommand _navRegisterCommand;
        public DelegateCommand NavRegisterCommand
        {
            get { return _navRegisterCommand = _navRegisterCommand ?? new DelegateCommand(NavRegisterCommandDelegate, CanNavRegisterCommandDelegate); }
        }
        public bool CanNavRegisterCommandDelegate()
        {
            return true;
        }
        public void NavRegisterCommandDelegate()
        {
            IsRegistering = true;
        }

        private DelegateCommand _registerCommand;
        public DelegateCommand RegisterCommand
        {
            get { return _registerCommand = _registerCommand ?? new DelegateCommand(RegisterCommandDelegate, CanRegisterCommandDelegate); }
        }
        public bool CanRegisterCommandDelegate()
        {
            return IsRegisteringValid;
        }
        public void RegisterCommandDelegate()
        {
            //NavigationService.NavigateToPage(ViewsEnum.MainPageView);
        }


        private DelegateCommand _cancelRegisterCommand;
        public DelegateCommand CancelRegisterCommand
        {
            get { return _cancelRegisterCommand = _cancelRegisterCommand ?? new DelegateCommand(CancelRegisterCommandDelegate, CanCancelRegisterCommandDelegate); }
        }
        public bool CanCancelRegisterCommandDelegate()
        {
            return true;
        }
        public void CancelRegisterCommandDelegate()
        {
            IsRegistering = false;
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
            if (args.Parameter != null && args.Parameter is Users)
            {
                var user = (Users)args.Parameter;
                Name = user.FirstName;
                Password = user.Password;
            }

            return null;
        }



        private async void LoadUser()
        {
            IsBusy = true;

            try
            {
                //var atribsList = await App.MobileService.GetTable<Products>().Skip(ItemsPerPage * _currentPage).Take(ItemsPerPage).ToListAsync();



                IsBusy = false;
            }
            catch (MobileServiceInvalidOperationException azureExc)
            {
                IsBusy = false;
                IDialogService dialogService = new DialogService();
                var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorConnection);
            }
            catch (Exception exc)
            {
                IsBusy = false;
                IDialogService dialogService = new DialogService();
                var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, exc.Message);
            }
        }

        /////////////////////////////////////////////////////////////////
        #endregion
    }
}