using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    class Row
    {
        private int _timeID;

        public int TimeID
        {
            get { return _timeID; }
            set { _timeID = value; }
        }

        private List<Employees> _deltagere;

        public List<Employees> Deltagere
        {
            get { return _deltagere; }
            set { _deltagere = value; }
        }
    
    }
}
