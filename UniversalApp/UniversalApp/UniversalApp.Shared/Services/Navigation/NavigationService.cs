using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using UniversalApp.ViewModels.Base;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UniversalApp.Views.Base;
using Windows.UI.Xaml.Media.Animation;
using UniversalApp.Views;

namespace UniversalApp.Services.Navigation
{
    public class NavigationService
    {
        public static ViewModelBase CurrentViewModel { get; set; }

        private static Frame _frame
        {
            get { return Window.Current.Content as Frame; }
        }

        public static bool NavigateToPage(Type targetPage, object parameter = null)
        {
            if (_frame != null)
            {
                if (parameter == null)
                    _frame.Navigate(targetPage);
                else
                    _frame.Navigate(targetPage, parameter);

                return true;
            }

            return false;
        }

        public static bool NavigateToPage(ViewsEnum targetview, object parameter = null)
        {
            if (_frame != null)
            {
                switch (targetview)
                {
                    case ViewsEnum.LoginView:
                        NavigateToPage(typeof(LoginView), parameter);
                        return true;
                    case ViewsEnum.DetailsView:
                        //NavigateToPage(typeof(DetailsView), parameter);
                        return true;
                    case ViewsEnum.CheckoutView:
                        //NavigateToPage(typeof(CheckoutView), parameter);
                        return true;
                    default:
                        NavigateToPage(typeof(MainPage), parameter);
                        return true;
                }
            }
            return false;
        }

    }
}
