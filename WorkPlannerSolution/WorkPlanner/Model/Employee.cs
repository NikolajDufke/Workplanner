using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    public  class Employee
    {

        public int EmployeeId { get; set; }
        public EmployeeInformation EmployeeInformation { get; set; }
        public Users Users { get; set; }
    }
}
