using System;
using WorkPlanner.Model.Databasemodels;

namespace WorkPlanner.Model
{
    public class Worktimes : DatabaseObject
    {
        public Worktimes(int workTimeId, int employeeId, DateTime date, DateTime time)
        {
            workTimeId = WorkTimeId;
            employeeId = EmployeeId;
            date = Date;
            time = Time;
        }

        public int WorkTimeId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}