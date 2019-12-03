using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    class RowViewItems
    {
        private List<TimeIntervalDetails> _listOfDetails;
        public RowViewItems()
        {
            
        }

        public TimeSpan Time { get; set; }

        public List<TimeIntervalDetails> TimeIntervalDetails
        {
            get { return _listOfDetails; }
            set { _listOfDetails = value; }
        }

        public string ListOfMembers
        {
            get { return TimeIntervalDetails.ToString(); }
        }

    }
}
