using System;

namespace WorkPlanner.Converter
{
    public static class DateTimeConverter
    {
        #region Converters
        /// <summary>
        /// Converter der konvertere DateTimeOffset og Timespan til DateTime
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime DateTimeOffsetAndTimeSetToDateTime(DateTimeOffset date, TimeSpan time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, 0);
        }

        /// <summary>
        /// Converter der konvertere DateTimeOffset til DateTime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime DateTimeOffsetToDateTime(DateTimeOffset date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        /// <summary>
        /// Converter der gør det samme som DateTimeOffsetToDateTime men som ikke har DateTimeOffset som parameter
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime TrimToDateOnly(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
        #endregion
    }
}