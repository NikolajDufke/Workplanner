using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model.Databasemodels;

namespace WorkPlanner.Model
{
    public class EmployeeInformations : DatabaseObject
    {
       
        public int EInformationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public int ZipPostal { get; set; }
    }
}
