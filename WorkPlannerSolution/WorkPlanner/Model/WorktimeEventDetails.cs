using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
   public class WorktimeEventDetails
    {
        public WorktimeEventDetails(string color, string name, int worktimeId)
        {
            _color = color;
            _name = name;
            _WorktimeId = worktimeId;
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

        private int _WorktimeId;

        public int WorktimeID
        {
            get { return _WorktimeId; }
            set { _WorktimeId = value; }
        }

  

    


    }
}
