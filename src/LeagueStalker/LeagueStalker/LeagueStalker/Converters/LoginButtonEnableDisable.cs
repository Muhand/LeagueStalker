using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace LeagueStalker.Converters
{
    class LoginButtonEnableDisable : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (bool)value;
            if (temp)
                return (Color)Application.Current.Resources["ThemeColor"];
            else
                return (Color)Application.Current.Resources["DisabledColor"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
