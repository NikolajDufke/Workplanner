using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    public class EventElement
    {
        //private List<System.Drawing.Color> _coletList;

        //public EventElement()
        //{
        //    _coletList = new List<Color>();
        //}

        //public List<System.Drawing.Color> Colors
        //{
        //    get { return _coletList; }
        //    set { _coletList = value; }
        //}


        private List<WorktimeEventDetails> _coletList;

        public EventElement()
        {
            _coletList = new List<WorktimeEventDetails>();
        }

        public List<WorktimeEventDetails> Colors
        {
            get { return _coletList; }
            set { _coletList = value; }
        }


    }
}
