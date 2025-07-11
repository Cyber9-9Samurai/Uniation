﻿using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Uniation.Converters
{
    class BorderColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int id)
            {
                return id % 2 == 0 ? new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#64110E")) : new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#165C53"));
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
