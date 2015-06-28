using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UniversalApp.Converters
{
    public class TextCurrencyConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            return value.ToString() + " " + Globals.Currency;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
