using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    public class WorktimeEventDetails
    {
        private string _color;
        private Employees _employee;
        private Worktimes _worktime;

        public WorktimeEventDetails(Employees employee, Worktimes worktime)
        {

            _employee = employee;
            _worktime = worktime;
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Name
        {
            get { return _employee.FirstName + " " + _employee.LastName; ; }
        }

        public int WorktimeID
        {
            get { return _worktime.WorkTimeID; }
        }

        public DateTime StarTime
        {
            get { return _worktime.TimeStart; }
        }

        public DateTime EndTime
        {
            get { return _worktime.TimeEnd; }
        }
    }
}
