using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfClient.ViewModel
{
    public class DateTimeToYearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.Year.ToString();
            }

            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParseExact(value as string, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }

            return DependencyProperty.UnsetValue; // Returning DependencyProperty.UnsetValue if convertation not possible or fails.
            //throw new NotImplementedException(); //Or we can throw exception
        }
    }
}
