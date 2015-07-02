using UniversalApp.ViewModels;
using UniversalApp.Views.Base;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp.Views
{
    public sealed partial class MainPage : PageBase
    {
        private ScrollViewer _scrollViewerProducts;

        public MainPageViewModel ViewModel
        {
            get { return ((MainPageViewModel)DataContext); }
        }

        public MainPage()
        {
            InitializeComponent();

            if (ViewModel != null)
            {
                ViewModel.LoadedRequest += AssignScrollViewer;
            }

            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private async void OnScrollViewerProducts_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer viewer = (ScrollViewer)sender;
            if (viewer.VerticalOffset >= viewer.ExtentHeight - viewer.ViewportHeight - 0.1)
            {
                await ViewModel.LoadProductsNextPage();
            }
        }

        private void AssignScrollViewer()
        {
            if (_scrollViewerProducts == null)
            {
                _scrollViewerProducts = GetScrollViewer(listViewProducts);
                _scrollViewerProducts.ViewChanged += OnScrollViewerProducts_ViewChanged;
            }
        }

        public static ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer) return depObj as ScrollViewer;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = GetScrollViewer(child);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
