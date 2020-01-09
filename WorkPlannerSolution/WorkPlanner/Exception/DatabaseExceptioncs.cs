using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Exception
{
   public class DatabaseExceptioncs : System.Exception
    {
        public DatabaseExceptioncs(string message):base(message)
        {
            
        }
    }
}
