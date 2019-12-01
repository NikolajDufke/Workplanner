using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    class AllViewItems
    {
        private Dictionary<TimeSpan, RowViewItems> rows;
        private int _maxColumnsIndex;

        private TimeSpan _timeSpan;
        private TimeSpan _starttime;
        private TimeSpan _endtime;

        public AllViewItems()
        {
            rows = new Dictionary<TimeSpan, RowViewItems>();

            _maxColumnsIndex = 8;

            _starttime = TimeSpan.FromHours(8);
            _endtime = TimeSpan.FromHours(22);
            _timeSpan = TimeSpan.FromMinutes(_endtime.TotalMinutes - _starttime.TotalMinutes);

            AddRows();

        }

        public ObservableCollection<RowViewItems> Rows
        {
            get
            {
                return new ObservableCollection<RowViewItems>(rows.Values);
            }
          
        }

        public List<string> Headers
        {
            get
            {
                return new List<string>()
                {
                    "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag"
                };
            }
        }


        public void Addmember(TimeSpan time, Employees member, int cloumn)
        {
            if (rows.ContainsKey(time))
            {
                rows[time].TimeIntervalDetails[cloumn].AddMember(member);
            }
        }


        private void AddRows(int intervalInMinutes = 30)
        {
            for (double i = _starttime.TotalMinutes; i < _endtime.TotalMinutes; i += intervalInMinutes)
            {

                List<TimeIntervalDetails> rvi = new List<TimeIntervalDetails>();
                for (int u = 0; u < _maxColumnsIndex; u++)
                {
                    rvi.Add(new TimeIntervalDetails());
                }

                rows.Add(TimeSpan.FromMinutes(i), new RowViewItems()
                {
                    Time = TimeSpan.FromMinutes(i),
                    TimeIntervalDetails = rvi
                });
            }
        }








    }
}
