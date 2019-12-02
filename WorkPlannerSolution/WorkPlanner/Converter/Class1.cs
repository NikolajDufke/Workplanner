using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WorkPlanner.Converter
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var lengthInTime = (TimeSpan)value;

            if (lengthInTime == TimeSpan.Zero)
            {
                return string.Empty;
            }

            return string.Format("{0:D2}:{1:D2}", lengthInTime.Hours, lengthInTime.Minutes);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string strValue = value as string;
            TimeSpan resultSpan;
            if (TimeSpan.TryParse(strValue, out resultSpan))
            {
                return resultSpan;
            }
            throw new Exception("Unable to convert string to date time");
        }
    }
}
