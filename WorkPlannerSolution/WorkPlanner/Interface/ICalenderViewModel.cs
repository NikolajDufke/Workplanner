using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkPlanner.Common;
using WorkPlanner.Model;

namespace WorkPlanner.Interface
{
    public interface ICalenderViewModel
    {
        bool ButtonStatus { get; set; }
        double CalenderOpacity { get; set; }
        string LoadinStatus { get; set; }
        ObservableCollection<WorktimeEventDetails> WorktimeEventDetails{get;set;}
        ObservableCollection<Employees> Employees { get; set; }      
        ObservableCollection<DateTime> Headers { get; set; }
        ObservableCollection<string> Times { get; set; }
        string Year { get; set; }
        int WeekNumber { get; set; }

        DateTime Day1Header { get; set; }
        DateTime Day2Header { get; set; }
        DateTime Day3Header { get; set; }
        DateTime Day4Header { get; set; }
        DateTime Day5Header { get; set; }
        DateTime Day6Header { get; set; }
        DateTime Day7Header { get; set; }

        ObservableCollection<EventElement> Weekday1Collection { get; set; }
        ObservableCollection<EventElement> Weekday2Collection { get; set; }
        ObservableCollection<EventElement> Weekday3Collection { get; set; }
        ObservableCollection<EventElement> Weekday4Collection { get; set; }
        ObservableCollection<EventElement> Weekday5Collection { get; set; }
        ObservableCollection<EventElement> Weekday6Collection { get; set; }
        ObservableCollection<EventElement> Weekday7Collection { get; set; }

        ICommand NextWeekCommand { get; set; }
        ICommand PreviousWeekCommand { get; set; }


    }

}

