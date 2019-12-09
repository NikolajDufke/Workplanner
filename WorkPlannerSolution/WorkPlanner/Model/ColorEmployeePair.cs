using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
   public class ColorEmployeePair
    {
        public ColorEmployeePair(string color, string name)
        {
            _color = color;
            _name = name;
        }

        private string _color;

        public string Color    
        {
            get { return _color; }
            set { _color = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }




    }
}
