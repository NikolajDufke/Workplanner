using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;
using Windows.UI.StartScreen;

namespace WorkPlanner.Common
{
    static class GetDatesFromWeekNumber
    {
        /// <summary>
        /// Retunere en liste af 7 datoer fra mandag til søndag til en given uge.
        /// </summary>
        /// <param name="weekNumber"></param>
        /// <returns></returns>
        public static List<DateTime> GetDates(DateTime startDate)
        {

            DateTime _startdate = startDate;

            if (_startdate.DayOfWeek == DayOfWeek.Monday)
                return SetListOfSevenDays(_startdate);

            while (_startdate.DayOfWeek != DayOfWeek.Monday)
            {
                _startdate = _startdate.Subtract(TimeSpan.FromDays(1));
            }

            return SetListOfSevenDays(_startdate);
        }

        private static List<DateTime> SetListOfSevenDays(DateTime startTime)
        {
            List<DateTime> listOfDates = new List<DateTime>();

            for (int i = 0; i < 7; i++)
            {
                DateTime t = startTime;
                listOfDates.Add(t.AddDays(i));
            }

            return listOfDates;
        }
    }


}

