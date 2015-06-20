using UniversalApp.ViewModels;
using UniversalApp.Views.Base;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.Views
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : PageBase
    {
        public MainPage()
        {
            InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }
    }
}
