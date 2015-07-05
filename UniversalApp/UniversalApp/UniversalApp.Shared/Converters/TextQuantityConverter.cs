using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UniversalApp.Converters
{
    public class TextQuantityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            return "x " + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
