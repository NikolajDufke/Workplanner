using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
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
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection1;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection2;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection3;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection4;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection5;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection6;
        private Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection7;
        private Dictionary<DateTime, TimeSpan> _times;
        private Dictionary<int, Employees> _employeePlacementIndexex;
        private Dictionary<int, Color> _colors;
        private List<Color> _manyColors;


        public AdminHandler(AdminPageViewModel ViewModel)
        {
            _times = new Dictionary<DateTime, TimeSpan>();
            _employeePlacementIndexex = new Dictionary<int, Employees>();
            _starttime = new TimeSpan(8, 00, 0);
            _endtime = new TimeSpan(23, 00, 0);
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

            _colors = new Dictionary<int, Color>();
          
            _manyColors.Add(Color.DarkMagenta);
            _manyColors.Add(Color.DarkOrange);
            _manyColors.Add(Color.DarkGreen);
            _manyColors.Add(Color.Aqua);
            _manyColors.Add(Color.Indigo);
            _manyColors.Add(Color.Plum);
            _manyColors.Add(Color.MediumPurple);
            //test data

            //_vm.Weekday1Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday1Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday1Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday1Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday1Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday1Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday1Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday1Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});

            //_vm.Weekday2Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday2Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday2Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday2Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday2Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday2Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday2Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});
            //_vm.Weekday2Collection.Add(new EventElement() {Colors = new List<string>() {"Blue", "Red", "Yellow"}});

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

            set
            {
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
        public void SetTimes(int intervalInMinutes = 30)
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

        public void UpdateTimePlan()
        {
            _vm.Weekday1Collection.Clear();
            foreach (TimeIntervalDetails tp in _timePlanCollection1.Values)
            {
                var e = new EventElement();
                for (int i = 0; i < _employeePlacementIndexex.Count; i++)
                {
                    if (tp.GetMembers.Contains(_employeePlacementIndexex[i]))
                    {
                        e.Colors.Add(_colors[i]);
                    }
                    else
                    {
                        e.Colors.Add(System.Drawing.Color.Empty);
                    }
                }

                _vm.Weekday1Collection.Add(e);

                _vm.Weekday1Collection.Add(new EventElement());
            }
        }


        private void PululateTimePlanCollections()
        {
            var Worktimecatalog = CatalogsSingletons<Worktimes>.Instance.Catalog.GetAll;
           
            int headerindex = 1;
            foreach (var header in _vm.Headers)
            {
                List<Worktimes> result = Worktimecatalog.FindAll(x =>
                    DateTime.Compare(Converter.DateTimeConverter.TrimToDateOnly(x.Date),
                        Converter.DateTimeConverter.TrimToDateOnly(header)) == 0);

                foreach (Worktimes worktime in result)
                {

                    switch (headerindex)
                    {
                        case 1:
                        {
                            FindAndAddEmployeesToTimePlan(_timePlanCollection1, worktime);
                            break;
                        }
                        case 2:
                        {
                            FindAndAddEmployeesToTimePlan(_timePlanCollection2, worktime);
                            break;
                        }
                        case 3:
                        {
                            FindAndAddEmployeesToTimePlan(_timePlanCollection3, worktime);
                            break;
                        }
                        case 4:
                        {
                            FindAndAddEmployeesToTimePlan(_timePlanCollection4, worktime);
                            break;
                        }
                        case 5:
                        {
                            FindAndAddEmployeesToTimePlan(_timePlanCollection5, worktime);
                            break;
                        }
                        case 6:
                        {
                            FindAndAddEmployeesToTimePlan(_timePlanCollection6, worktime);
                            break;
                        }
                        case 7:
                        {
                            FindAndAddEmployeesToTimePlan(_timePlanCollection7, worktime);
                            break;
                        }

                    }
                }

                headerindex++;


            }
        }

        private async void FindAndAddEmployeesToTimePlan(Dictionary<TimeSpan, TimeIntervalDetails> collection,
            Worktimes worktime)
        {
            var EmployeeCatalog = CatalogsSingletons<Employees>.Instance.Catalog;


            for (int i = worktime.TimeStart.TimeOfDay.Minutes; i < worktime.TimeEnd.TimeOfDay.Minutes; i += 30)
            {
                TimeSpan t = new TimeSpan(i);

                if (collection.ContainsKey(t))
                {
                    Employees e = await EmployeeCatalog.GetSingleAsync(worktime.EmployeeID.ToString());

                    if (!_employeePlacementIndexex.ContainsValue(e))
                    {
                        _employeePlacementIndexex[_employeePlacementIndexex.Count + 1] = e;
             
                    }

                    collection[t].AddMember(e);
                }
            }
        }


    }


}


