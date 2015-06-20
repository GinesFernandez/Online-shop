using System.Threading.Tasks;
using UniversalApp.Services.Dialogs;
using UniversalApp.Services.Navigation;
using UniversalApp.ViewModels.Base;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Declarations
        /////////////////////////////////////////////////////////////////
        private readonly IDialogService _dialogService;

        /////////////////////////////////////////////////////////////////
        #endregion

        #region Properties
        /////////////////////////////////////////////////////////////////

        public bool Logged
        {
            get { return Globals.CurrentUser != null; }
        }

        //private int _contador;
        //public int Contador
        //{
        //    get { return _contador; }
        //    set
        //    {
        //        if (value != _contador)
        //        {
        //            _contador = value;
        //            RaisePropertyChanged();
        //        }
        //    }
        //}

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
            NavigationService.NavigateToPage(ViewsEnum.LoginPage);
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
            return null;
        }

        /////////////////////////////////////////////////////////////////
        #endregion
    }
}
