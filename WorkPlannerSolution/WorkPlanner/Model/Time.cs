using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    class Time
    {
        private TimeSpan _time;

        public TimeSpan GetTime
        {
            get { return _time; }
            set { _time = value; }
        }

        private int _timeID;

        public int TimeID
        {
            get { return _timeID; }
            set { _timeID = value; }
        }


    }
}
