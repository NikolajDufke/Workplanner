using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    public class PropInfo
    {
        private string _visualName;
        private string _propName;
        private string _valueFromUser;

        public string ValueFromUser
        {
            get { return _valueFromUser; }
            set { _valueFromUser = value; }
        }

        public string PropName
        {
            get { return _propName; }
            set { _propName = value; }
        }

        public string VisualName
        {
            get { return _visualName; }
            set { _visualName = value; }
        }

    }
}
