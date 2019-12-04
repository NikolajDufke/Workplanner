using System;

namespace WorkPlanner.Converter
{
    public static class DateTimeConverter
    {
            public static DateTime DateTimeOffsetAndTimeSetToDateTime(DateTimeOffset date, TimeSpan time)
            {
                return new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, 0);
            }

            public static DateTime DateTimeOffsetToDateTime(DateTimeOffset date)
            {
                return new DateTime(date.Year, date.Month, date.Day);
            }

            public static DateTime TrimToDateOnly(DateTime date)
            {
                return  new DateTime(date.Year,date.Month,date.Day);
            }
    }
}