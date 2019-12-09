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
       public static List<DateTime> GetDates(int weekNumber)
       {
           List<DateTime> listOfDates = new List<DateTime>();
            DateTime now = DateTime.Now;
            int startdate = weekNumber * 7;
      

            for (int i = 0; i < 7; i++)
            {
                var t = new DateTime(now.Year, 1,1).Add(new TimeSpan(startdate - 1 + i, 0 ,0,0));
                listOfDates.Add(t);
            }

            return listOfDates;

       }
    }
}
