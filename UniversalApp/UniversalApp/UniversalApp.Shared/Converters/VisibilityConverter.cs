using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UniversalApp.Converters
{
    public class InverseBoolToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            var val = value as bool?;
            return val == true ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            var val = value as bool?;
            return val == true ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
