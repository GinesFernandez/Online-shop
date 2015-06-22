using UniversalApp.Services.Dialogs;
using Microsoft.Practices.Unity;

namespace UniversalApp.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();
            _container.RegisterType<MainPageViewModel>();
            _container.RegisterType<LoginViewModel>();
            _container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
        }

        public MainPageViewModel MainPageViewModel
        {
            get { return _container.Resolve<MainPageViewModel>(); }
        }

        public LoginViewModel LoginViewModel
        {
            get { return _container.Resolve<LoginViewModel>(); }
        }

        //public DetailsViewModel DetailsViewModel
        //{
        //    get { return _container.Resolve<DetailsViewModel>(); }
        //}

        //public CheckoutViewModel CheckoutViewModel
        //{
        //    get { return _container.Resolve<CheckoutViewModel>(); }
        //}
    }
}
