using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
using Windows.UI.Xaml;
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
        private Dictionary<int, string> _colors;
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

           
            _vm.WeekNumber = DateTime.Now.DayOfYear / 7;

            _vm.Headers.Clear();
            foreach (var date in GetDatesFromWeekNumber.GetDates(_vm.WeekNumber))
            {
                _vm.Headers.Add(date);
            }

            //_colors = new Dictionary<int, Color>();

            //_colors.Add(1, Color.DarkMagenta);
            //_colors.Add(2, Color.DarkOrange);
            //_colors.Add(3, Color.DarkGreen);
            //_colors.Add(4, Color.Aqua);
            //_colors.Add(5, Color.Indigo);
            //_colors.Add(6, Color.Plum);
            //_colors.Add(7, Color.MediumPurple);

            _colors = new Dictionary<int, string>();

            _colors.Add(1,"DarkMagenta");
            _colors.Add(2, "DarkOrange");
            _colors.Add(3, "DarkGreen");
            _colors.Add(4, "Aqua");
            _colors.Add(5, "Indigo");
            _colors.Add(6, "Plum");
            _colors.Add(7, "MediumPurple");


            SetTimes();
            PululateTimePlanCollectionsAsync();




            //test data



            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });

            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow } });


            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });

            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_vm.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });


            UpdateObsCollection updater = new UpdateObsCollection();
            updater.GetEmployeesAsync(_vm.Employees);
        }

        public void ChangeEmployeeVisibility()
        {

            if (_vm.EmployeeVisibility == Visibility.Collapsed)
            {
                _vm.EmployeeVisibility = Visibility.Visible;
            }
            else
            {
                _vm.EmployeeVisibility = Visibility.Collapsed;
            }
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
            _vm.Weekday2Collection.Clear();
            _vm.Weekday3Collection.Clear();
            _vm.Weekday4Collection.Clear();
            _vm.Weekday5Collection.Clear();
            _vm.Weekday6Collection.Clear();
            _vm.Weekday7Collection.Clear();

            int headerindex = 1;
            foreach (var header in _vm.Headers)
            {

                switch (headerindex)
                {
                    case 1:
                    {
                        AddToView(_timePlanCollection1, _vm.Weekday1Collection);
                        break; 
                    }
                    case 2:
                    {
                        AddToView(_timePlanCollection2, _vm.Weekday2Collection);
                            break;
                    }
                    case 3:
                    {
                        AddToView(_timePlanCollection3, _vm.Weekday3Collection);
                            break;
                    }
                    case 4:
                    {
                        AddToView(_timePlanCollection4, _vm.Weekday4Collection);
                            break;
                    }
                    case 5:
                    {
                        AddToView(_timePlanCollection5, _vm.Weekday5Collection);
                            break;
                    }
                    case 6:
                    {
                        AddToView(_timePlanCollection6, _vm.Weekday6Collection);
                            break;
                    }
                    case 7:
                    {
                        AddToView(_timePlanCollection7, _vm.Weekday7Collection);
                            break;
                    }
                }

                headerindex++;

            }
         }

        private void AddToView(Dictionary<TimeSpan, TimeIntervalDetails> collection, ObservableCollection<EventElement> collectionToUpdate)
        {
            foreach (TimeIntervalDetails tp in collection.Values)
            {
                var e = new EventElement();
                for (int i = 1; i < _employeePlacementIndexex.Count +1; i++)
                {
                      if (tp.GetMembers.Contains(_employeePlacementIndexex[i]))
                    {
                        e.Colors.Add(_colors[i]);
                    }
                    else
                    {
                        e.Colors.Add("");
                    }
                }

                collectionToUpdate.Add(e);

            }

        }
    

    private async void PululateTimePlanCollectionsAsync()
        {
            List<Worktimes> Worktimecatalog = await CatalogsSingleton.Instance.WorktimeCatalog.GetAll();
           
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
                            await FindAndAddEmployeesToTimePlanAsync(_timePlanCollection1, worktime);
                            break;
                        }
                        case 2:
                        {
                            await  FindAndAddEmployeesToTimePlanAsync(_timePlanCollection2, worktime);
                              break;
                        }
                        case 3:
                        {
                           await FindAndAddEmployeesToTimePlanAsync(_timePlanCollection3, worktime);
                            break;
                        }
                        case 4:
                        {
                           await FindAndAddEmployeesToTimePlanAsync(_timePlanCollection4, worktime);
                            break;
                        }
                        case 5:
                        {
                           await FindAndAddEmployeesToTimePlanAsync(_timePlanCollection5, worktime);
                            break;
                        }
                        case 6:
                        {
                           await FindAndAddEmployeesToTimePlanAsync(_timePlanCollection6, worktime);
                            break;
                        }
                        case 7:
                        {
                           await FindAndAddEmployeesToTimePlanAsync(_timePlanCollection7, worktime);
                            break;
                        }

                    }
                }

                headerindex++;
            }

             UpdateTimePlan();
        }

        private async Task FindAndAddEmployeesToTimePlanAsync(Dictionary<TimeSpan, TimeIntervalDetails> collection,
            Worktimes worktime)
        {
            var EmployeeCatalog = CatalogsSingleton.Instance.EmployeeCatalog;
            int id = worktime.EmployeeID;
            Employees e = await EmployeeCatalog.GetSingleAsync(id.ToString());
            


            for (double i = worktime.TimeStart.TimeOfDay.TotalMinutes; i < worktime.TimeEnd.TimeOfDay.TotalMinutes; i += 30)
            {
                TimeSpan t = TimeSpan.FromMinutes(Convert.ToInt32(i));
                

                if (collection.ContainsKey(t))
                {
                    


                    bool contains = false;
                    foreach (Employees eFromIndex in _employeePlacementIndexex.Values)
                    {

                        if (e.EmployeeID == eFromIndex.EmployeeID)
                        {
                            contains = true;
                        }
                    }

                    if (!contains)
                    {
                        _employeePlacementIndexex[_employeePlacementIndexex.Count + 1] = e;
                    }

                    collection[t].AddMember(e) ;
                }
            }
        }
        

    }
    

}


