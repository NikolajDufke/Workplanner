using System;

namespace WorkPlanner.Model
{
    public class Worktime
    {
        public int WorkTimeId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}