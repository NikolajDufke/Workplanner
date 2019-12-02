using System;

namespace WorkPlanner.Model
{
    public class Worktimes
    {

        public int WorkTimeID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime Date { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

    }
}