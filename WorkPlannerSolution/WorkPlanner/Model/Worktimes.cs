using System;

namespace WorkPlanner.Model
{
    public class Worktimes
    {
        public Worktimes()
        {
        }

        public int WorkTimeID { get; set; }

        public int EInformationID { get; set; }

        public DateTime Date { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public virtual EmployeeInformations EmployeeInformation { get; set; }

    }
}