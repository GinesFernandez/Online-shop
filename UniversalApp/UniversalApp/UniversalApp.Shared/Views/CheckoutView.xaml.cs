using UniversalApp.Views.Base;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.Views
{
    public sealed partial class CheckoutView : PageBase
    {
        public CheckoutView()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }
    }
}
