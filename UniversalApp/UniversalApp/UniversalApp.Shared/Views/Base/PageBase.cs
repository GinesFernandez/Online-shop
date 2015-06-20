using UniversalApp.Services.Navigation;
using UniversalApp.ViewModels.Base;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.Views.Base
{
    public class PageBase : Page
    {
        private ViewModelBase _vm;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _vm = (ViewModelBase)DataContext;
            NavigationService.CurrentViewModel = _vm;

            if (_vm != null)
            {
                _vm.SetAppFrame(Frame);
                _vm.OnNavigatedTo(e);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (_vm != null)
                _vm.OnNavigatedFrom(e);
        }
    }
}
