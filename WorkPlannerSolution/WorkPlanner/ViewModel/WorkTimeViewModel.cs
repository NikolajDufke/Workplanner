using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkPlanner.Common;
using WorkPlanner.Handler;

namespace WorkPlanner.ViewModel
{
    public class WorkTimeViewModel
    {
        private int _id;
        private DateTimeOffset _dateTime;
        private TimeSpan _time;
        private WorkTimeHandler _workTimeHandler;


        public WorkTimeViewModel()
        {
            _workTimeHandler = new WorkTimeHandler(this );

            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
        }

        public int ID
        {
            get { return _id; }
        }

        public DateTimeOffset Date
        {
            set { _dateTime = value; }
            get { return _dateTime; }
        }

        public TimeSpan Time
        {
            set { _time = value; }
            get { return _time; }
        }

        public WorkTimeHandler Worktimeh
        {
            set { _workTimeHandler = value; }
            get { return _workTimeHandler; }
        }
    }
}