using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model.Databasemodels;

namespace WorkPlanner.Model
{
   public class Accesses : DatabaseObject
    {
        public int AccessLevel { get; set; }
        public string Decription { get; set; }
    }
}
