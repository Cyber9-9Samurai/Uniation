using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Uniation.Converters
{
    class ColorConverter : IValueConverter
    {
         public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int id)
            {
                return id % 2 == 0 ? new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#F45952")) : new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#4D9E93"));
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
