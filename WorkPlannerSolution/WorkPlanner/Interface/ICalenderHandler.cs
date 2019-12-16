using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;

namespace WorkPlanner.Interface
{
    public interface ICalenderHandler
    {
        TimeSpan StartTimeSpan { set; }
        TimeSpan Endtime { set; }
        void LoadCalenderDetailsAsync();
        void AddWeekNumber();
        void SubstractWeekNumber();
    


    }
}
