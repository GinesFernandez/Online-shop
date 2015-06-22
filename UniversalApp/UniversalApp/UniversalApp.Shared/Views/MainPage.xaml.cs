using UniversalApp.Views.Base;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.Views
{
    public sealed partial class MainPage : PageBase
    {
        public MainPage()
        {
            InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }
    }
}
