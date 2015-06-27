using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using UniversalApp.Helpers;
using UniversalApp.Model;
using UniversalApp.Services;
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

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
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

        private Users _newUser = new Users() { Id = Guid.NewGuid(), Title = Cadenas.DefaultTitle };
        public Users NewUser
        {
            get { return _newUser; }
            set
            {
                if (value != _newUser)
                {
                    _newUser = value;
                    RaisePropertyChanged();
                    RegisterCommand.RaiseCanExecuteChanged();
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
            return !String.IsNullOrWhiteSpace(Password) && !String.IsNullOrWhiteSpace(Email) && !IsBusy;
        }
        public void LoginCommandDelegate()
        {
            LoadUser();
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
            return !IsBusy;
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
                Email = user.Email;
                Password = user.Password;
            }

            return null;
        }

        public override void EnableDisableControls(bool enabled = true)
        {
            LoginCommand.RaiseCanExecuteChanged();
            RegisterCommand.RaiseCanExecuteChanged();
        }

        private async void LoadUser()
        {
            if (!IsLoginEmailValid())
            {
                IDialogService dialogService = new DialogService();
                await dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorEmailNotValid);
                return;
            }

            ProgressBarONOFF();

            try
            {
                var users = await App.MobileService.GetTable<Users>().Where(x => x.Email == Email).ToListAsync();

                if (users.Count > 0)
                {
                    Users user = users[0];
                    SecurityService securityServ = new SecurityService();

                    if (user.Password == securityServ.Encrypt(Password)) //should be done by backend
                    {
                        //TODO: save user information for next app run
                        //StorageHelper.Save(user);

                        //TODO: update user login counter

                        Globals.CurrentUser = user;
                        NavigationService.NavigateToPage(ViewsEnum.MainPage);
                    }
                    else
                    {
                        IDialogService dialogService = new DialogService();
                        var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorIncorrectPassword);
                    }
                }
                else
                {
                    IDialogService dialogService = new DialogService();
                    var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, String.Format(Cadenas.ErrorUserNotExists, Email));
                }

                ProgressBarONOFF(false);
                LoginCommand.RaiseCanExecuteChanged();
                RegisterCommand.RaiseCanExecuteChanged();
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

        private bool IsLoginEmailValid()
        {
            return ValidationHelper.IsValidEmail(Email);
        }

        //private bool IsRegisterEmailValid()
        //{
        //    return ValidationHelper.IsValidEmail(EmailRegister);
        //}


        /////////////////////////////////////////////////////////////////
        #endregion
    }
}