using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model.Databasemodels;

namespace WorkPlanner.Model
{
    public class Users : DatabaseObject
    {
        public int UserID { get; set; }
        public string UserPassword { get; set; }
        public int AccessLevel { get; set; }
    }
}
