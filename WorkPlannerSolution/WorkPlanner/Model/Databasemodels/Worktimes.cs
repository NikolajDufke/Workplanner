using System;
using WorkPlanner.Model.Databasemodels;

namespace WorkPlanner.Model
{
    public class Worktimes : DatabaseObject
    {

        public int WorkTimeID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime Date { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

    }
}