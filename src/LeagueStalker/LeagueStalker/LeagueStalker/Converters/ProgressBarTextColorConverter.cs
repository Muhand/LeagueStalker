using System;
using System.Globalization;
using Xamarin.Forms;

namespace LeagueStalker.Converters
{
    public class ProgressBarTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return !((bool)value);
            if ((double)value >= 50.00)
                return Color.FromHex("#00FF00");
            else
                return Color.FromHex("#FF0000");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
