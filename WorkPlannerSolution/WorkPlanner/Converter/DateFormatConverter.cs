using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace WorkPlanner.Converter
{
    /// <summary>
    /// Converts from  a DateTime to a string fortattet dd/MM.
    /// </summary>
    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                DateTime dt = DateTime.Parse(value.ToString());
                return dt.ToString("dd/MM");
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}