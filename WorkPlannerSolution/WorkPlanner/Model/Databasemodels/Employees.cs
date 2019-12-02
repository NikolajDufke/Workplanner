using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model.Databasemodels;

namespace WorkPlanner.Model
{
    public  class Employees : DatabaseObject
    {

        public int EmployeeId { get; set; }

        public int UserID { get; set; }

        public int EInformationID { get; set; }
  
    }
}
