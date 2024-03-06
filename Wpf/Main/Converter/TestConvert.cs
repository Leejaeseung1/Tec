using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Main.Converter
{
    internal class TestConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not int boolean)
            {
                return DependencyProperty.UnsetValue;
            }
            return boolean > 3 ? "ok" : "no";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "back";
        }
    }
}
