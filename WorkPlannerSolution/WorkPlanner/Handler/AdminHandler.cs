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
using WorkPlanner.Proxy;
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
        private Proxy.WorktimeProxy _catalogInterface;

        public AdminHandler(AdminPageViewModel ViewModel)
        {
            _times = new Dictionary<DateTime, TimeSpan>();
            _employeePlacementIndexex = new Dictionary<int, Employees>();
            _starttime = new TimeSpan(8, 00, 0);
            _endtime = new TimeSpan(23, 00, 0);
            _catalogInterface = new WorktimeProxy();
           

            #region timePlanCollection initialization
            _timePlanCollection1 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection2 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection3 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection4 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection5 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection6 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            _timePlanCollection7 = new Dictionary<TimeSpan, TimeIntervalDetails>();
            #endregion

            #region Color Selection
            _colors = new Dictionary<int, string>();
            _colors.Add(1, "DarkMagenta");
            _colors.Add(2, "DarkOrange");
            _colors.Add(3, "DarkGreen");
            _colors.Add(4, "Aqua");
            _colors.Add(5, "Indigo");
            _colors.Add(6, "Plum");
            _colors.Add(7, "MediumPurple");
            #endregion

            _vm = ViewModel;
            _vm.WeekNumber = DateTime.Now.DayOfYear / 7;
            _vm.Year = DateTime.Now.Year.ToString();
            LoadCalenderDetailsAsync();

            SetTimes();
            PululateTimePlanCollectionsAsync();

            #region test data






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
        /// <summary>
        /// En metode som ændrer synligheden på et grid i vores view
        /// Metoden bruger viewmodellens property - EmployeeVisibility
        /// </summary>
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

        #region prperties 

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

                #endregion

        #region LoadDetails

        /// <summary>
        /// Står for at loade calenderen med til datoer og events.
        /// </summary>
        private async void LoadCalenderDetailsAsync()
        {
            _vm.Headers.Clear();
            foreach (var date in GetDatesFromWeekNumber.GetDates(_vm.WeekNumber))
            {
                _vm.Headers.Add(date);
            }

            //Sætter yå ud fra den første dato.
            //TODO gør at den finder år ud fra alle datoer og skriver 2 årstal på når vi er i ugen omkring årsskiftet.
            if (_vm.Year != _vm.Headers[1].Year.ToString())
            {
                _vm.Year = _vm.Headers[1].Year.ToString();
            }

           

            SetTimes();
            await PululateTimePlanCollectionsAsync();
            SetDaysAndDates();
            
        }

        /// <summary>
        /// Addere ugenummer med 1 og opdatere viewet med ny datoer og events.
        /// </summary>
        public void AddWeekNumber()
        {
           var t=  _vm.Day1Header.DayOfYear;
            DateTime nextWeek = _vm.Day1Header;
            nextWeek = nextWeek.AddDays(7);
            _vm.WeekNumber = nextWeek.DayOfYear / 7;
            LoadCalenderDetailsAsync();
            
        }

        /// <summary>
        /// Subtraktion af ugenummer med 1 og opdatere viewet med ny datoer og events.
        /// </summary>
        public void SubstractWeekNumber()
        {
            var t = _vm.Day1Header.DayOfYear;
            DateTime nextWeek = _vm.Day1Header;
            nextWeek = nextWeek.Subtract(TimeSpan.FromDays(7));
            _vm.WeekNumber = nextWeek.DayOfYear / 7;
            LoadCalenderDetailsAsync();
        }

        #endregion

        #region Opdatering af viewet 

        /// <summary>
        /// Sætter alle headers med datoer fra headers collection
        /// </summary>
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

        /// <summary>
        /// Opdatere tiderne på viewet og i timePlanCollections
        /// </summary>
        /// <param name="intervalInMinutes"></param>
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

        /// <summary>
        /// Opdatere viewet med tidsplanen fra TimePlanCollection.
        /// </summary>
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

        /// <summary>
        /// Tilføjer en DayCollection i viewet med data fra en TimePlanCollection
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="collectionToUpdate"></param>
        private void AddToView(Dictionary<TimeSpan, TimeIntervalDetails> collection, ObservableCollection<EventElement> collectionToUpdate)
        {
            

            foreach (TimeIntervalDetails tp in collection.Values)
            {
                
                    var e = new EventElement();
                    if (tp.Update)
                    {
                    for (int i = 1; i < _employeePlacementIndexex.Count + 1; i++)
                    {

                        // Vi matcher alle employees 
                        bool contains = false;
                        foreach (Employees member in tp.GetMembers)
                        {
                            foreach (Employees Eplacement in _employeePlacementIndexex.Values)
                            {
                                if (member.EmployeeID == Eplacement.EmployeeID)
                                    contains = true;
                            }
                        }

                        if (contains)
                        {
                            e.Colors.Add(_colors[i]);
                        }
                        else
                        {
                            e.Colors.Add("");
                        }
                    }
                }

                collectionToUpdate.Add(e);
            }
        }

        /// <summary>
        /// Finder worktimes i Databasen og sætter dem ind i TimeplanColletions.
        /// </summary>
        /// <returns></returns>
        private async Task PululateTimePlanCollectionsAsync()
        {  
            int headerindex = 1;
            foreach (var header in _vm.Headers)
            {
                //Her finder vi alle worktimes som er på en given dag.
                List<Worktimes> WorktimesThisDay = _catalogInterface.GetAllWorktimesOfDay(header.Date);

                foreach (Worktimes worktime in WorktimesThisDay)
                {
                    // Her tilføjer vi de worktimes til timePlanCollections. dato og cællerne følger hindanden ved hjælp af headerindex
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

            // Her opdatere vi vievet.
             UpdateTimePlan();
        }

        /// <summary>
        /// Her tiltøjer vi timePlanCollections til viewet.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="worktime"></param>
        /// <returns></returns>
        private async Task FindAndAddEmployeesToTimePlanAsync(Dictionary<TimeSpan, TimeIntervalDetails> collection,
            Worktimes worktime)
        {
            //først finder vi empluyee id på den employee som har worktimes
            var EmployeeCatalog = CatalogsSingleton.Instance.EmployeeCatalog;
            int id = worktime.EmployeeID;
            Employees e = await EmployeeCatalog.GetSingleAsync(id.ToString());           

            //Herefter kigger vi igennem alle tiderne og sætter employeen på når det svare til hans tidsplan.
            for (double i = worktime.TimeStart.TimeOfDay.TotalMinutes; i < worktime.TimeEnd.TimeOfDay.TotalMinutes; i += 30)
            {
                TimeSpan t = TimeSpan.FromMinutes(Convert.ToInt32(i));

                if (collection.ContainsKey(t))
                {
                    //Hen finder vi ud af om han alle rede findes i _employeePlacementIndexex. dette bestemmer hvilken rækkefølge de bliver vis i på viewet.
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
        #endregion
    }
}
#endregion