using System;
using System.Globalization;
using System.Windows.Data;

namespace ArithmetiqueAppMVVM.Converters
{
    public class DisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           double input = (double)value;
            string output = $"Le resultat est {input}";
            return output ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
