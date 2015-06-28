using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace UniversalApp.Converters
{
    public class StringPathToGeometryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            var val = value as string;
            if (!String.IsNullOrEmpty(val))
            {
                Path path = XamlReader.Load("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Data=\"" + val + "\"/>") as Path;
                return path.Data;
            }
            else
                return new Path().Data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
