using UniversalApp.Views.Base;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.Views
{
    public sealed partial class LoginView : PageBase
    {
        public LoginView()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }
    }
}
