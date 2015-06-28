using Microsoft.WindowsAzure.MobileServices;
using System;
using System.ComponentModel;
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

        private string _password2;
        public string Password2
        {
            get { return _password2; }
            set
            {
                if (value != _password2)
                {
                    _password2 = value;
                    RaisePropertyChanged();
                    RegisterCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private Users _newUser = new Users() { Title = Cadenas.DefaultTitle };
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

            _newUser.PropertyChanged += NewUser_PropertyChanged;
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

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new DelegateCommand(LoginCommandDelegate, CanLoginCommandDelegate); }
        }
        public bool CanLoginCommandDelegate()
        {
            return !IsBusy && !String.IsNullOrWhiteSpace(Password) && !String.IsNullOrWhiteSpace(Email);
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
            return !IsBusy;
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
            return !IsBusy && _newUser.AllMandatoryFieldsFilled;
        }
        public void RegisterCommandDelegate()
        {
            CreateUser();
        }


        private DelegateCommand _cancelRegisterCommand;
        public DelegateCommand CancelRegisterCommand
        {
            get { return _cancelRegisterCommand = _cancelRegisterCommand ?? new DelegateCommand(CancelRegisterCommandDelegate, CanCancelRegisterCommandDelegate); }
        }
        public bool CanCancelRegisterCommandDelegate()
        {
            return !IsBusy;
        }
        public void CancelRegisterCommandDelegate()
        {
            IsRegistering = false;
        }
        /////////////////////////////////////////////////////////////////
        #endregion

        #region Methods
        /////////////////////////////////////////////////////////////////
        
        private void NewUser_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RegisterCommand.RaiseCanExecuteChanged();
        }

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
            BackCommand.RaiseCanExecuteChanged();
            CancelRegisterCommand.RaiseCanExecuteChanged();
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

        private async void CreateUser()
        {
            if (!IsRegisterEmailValid())
            {
                IDialogService dialogService = new DialogService();
                await dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorEmailNotValid);
                return;
            }
            if (!IsPasswordConfirmValid())
            {
                IDialogService dialogService = new DialogService();
                await dialogService.ShowAsync(MessageBoxButton.OK, Cadenas.ErrorPasswordConfirmNotValid);
                return;
            }
            //TODO: check valid zipcode

            ProgressBarONOFF();

            try
            {
                var users = await App.MobileService.GetTable<Users>().Where(x => x.Email == Email).ToListAsync();

                if (users.Count == 0)
                {
                    SecurityService securityServ = new SecurityService();
                    _newUser.Password = securityServ.Encrypt(_newUser.Password); //should be done by backend

                    await App.MobileService.GetTable<Users>().InsertAsync(_newUser);

                    //TODO: save user information for next app run
                    //StorageHelper.Save(user);
                    Globals.CurrentUser = _newUser;
                    NavigationService.NavigateToPage(ViewsEnum.MainPage);

                }
                else
                {
                    IDialogService dialogService = new DialogService();
                    var dialogResult = dialogService.ShowAsync(MessageBoxButton.OK, String.Format(Cadenas.ErrorUserAlreadyExists, Email));
                }

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

        private bool IsLoginEmailValid()
        {
            return ValidationHelper.IsValidEmail(_email);
        }

        private bool IsRegisterEmailValid()
        {
            return ValidationHelper.IsValidEmail(NewUser.Email);
        }

        private bool IsPasswordConfirmValid()
        {
            return _newUser.Password.Equals(_password2);
        }
        /////////////////////////////////////////////////////////////////
        #endregion
    }
}