using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{



    public class AdminHandler
    {
        private AdminPageViewModel _vm;
        private TimeSpan _starttime;
        private TimeSpan _endtime;
        private Dictionary<TimeSpan , TimeIntervalDetails> _timePlanCollection1;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection2;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection3;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection4;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection5;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection6;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection7;
        private Dictionary<DateTime, TimeSpan> _times;

        public AdminHandler(AdminPageViewModel ViewModel)
        {
            _times = new Dictionary<DateTime, TimeSpan>();

            _starttime = new TimeSpan(8, 00, 0);
            _endtime =  new TimeSpan(23, 00, 0);
            _timePlanCollection1 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection2 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection3 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection4 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection5 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection6 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection7 = new Dictionary<TimeSpan, TimeIntervalDetails>();

            _vm = ViewModel;


            _vm.Headers.Clear();
            _vm.WeekNumber = DateTime.Now.DayOfYear / 7;


            foreach (var date in GetDatesFromWeekNumber.GetDates(_vm.WeekNumber))
            {
                _vm.Headers.Add(date);
            }



            //test data

            _vm.Weekday1Collection.Add(new EventElement(){Colors = new List<string>(){"Blue", "Red", "Yellow"}});
            _vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });

            _vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            _vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });

        }


        public void SetDaysAndDates()
        {

            _vm.Day1Header = _vm.Headers[0];
            _vm.Day2Header = _vm.Headers[1];
            _vm.Day3Header = _vm.Headers[2];
            _vm.Day4Header = _vm.Headers[3];
            _vm.Day5Header = _vm.Headers[4];
            _vm.Day6Header = _vm.Headers[5];
            _vm.Day7Header = _vm.Headers[6];

        }


        public TimeSpan StartTimeSpan
        {

            set
            {
                if (_starttime != value)
                {
                    _starttime = value;
                    SetTimes();
                }
            }
        }

        public TimeSpan Endtime
        {
       
            set {
                if (_endtime != value)
                {
                    _endtime = value;
                    SetTimes();
                }
            }
        }

        private int _uge;

        public int Uge
        {
            get { return _uge; }
            set { _uge = value; }
        }




        public void SetTimes( int intervalInMinutes = 30)
        {


            _vm.Times.Clear();
            _timePlanCollection1.Clear();
            _timePlanCollection2.Clear();
            _timePlanCollection3.Clear();
            _timePlanCollection4.Clear();
            _timePlanCollection5.Clear();
            _timePlanCollection6.Clear();
            _timePlanCollection7.Clear();

            for (double i = _starttime.TotalMinutes; i < _endtime.TotalMinutes; i += intervalInMinutes)
            {

                _vm.Times.Add(TimeSpan.FromMinutes(i));
                _timePlanCollection1.Add(TimeSpan.FromMinutes(i), new TimeIntervalDetails());
                _timePlanCollection2.Add(TimeSpan.FromMinutes(i), new TimeIntervalDetails());
                _timePlanCollection3.Add(TimeSpan.FromMinutes(i), new TimeIntervalDetails());
                _timePlanCollection4.Add(TimeSpan.FromMinutes(i), new TimeIntervalDetails());
                _timePlanCollection5.Add(TimeSpan.FromMinutes(i), new TimeIntervalDetails());
                _timePlanCollection6.Add(TimeSpan.FromMinutes(i), new TimeIntervalDetails());
                _timePlanCollection7.Add(TimeSpan.FromMinutes(i), new TimeIntervalDetails());

            }
        }

        private void PululateTimePlanCollections()
        {
            var catalog = CatalogsSingletons<Employees>.Instance.Catalog.GetAll;

            //var result = catalog.FindAll(x => x.Date == )
          

            foreach (var time in _vm.Times)
            {
                
            }
        }
    }
}
