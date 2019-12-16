using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Model;
using WorkPlanner.Proxy;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    public class CalendarHandler <T> where T: CalendarViewModelBase
    {
        protected T _viewmodel;
        private TimeSpan _starttime;
        private TimeSpan _endtime;
        protected Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection1;
        protected Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection2;
        protected Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection3;
        protected Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection4;
        protected Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection5;
        protected Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection6;
        protected Dictionary<TimeSpan, TimeIntervalDetails> _timePlanCollection7;
        
        private Dictionary<DateTime, TimeSpan> _times;

        //private Dictionary<int, Employees> _employeePlacementIndex;
        protected EmployeePlacementIndex _employeePlacementIndex;
        private Dictionary<int, string> _colors;

        protected WorktimeProxy _catalogInterface;
        //private Dictionary< WorktimeEventDetails> _cepair;


        public CalendarHandler(T viewmodel)
        {
            _viewmodel = viewmodel;
            _times = new Dictionary<DateTime, TimeSpan>();
            _employeePlacementIndex = new EmployeePlacementIndex();
            _starttime = new TimeSpan(8, 00, 0);
            _endtime = new TimeSpan(23, 00, 0);
            _catalogInterface = new WorktimeProxy();
            //_cepair = new List<WorktimeEventDetails>();

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

            _viewmodel.WeekNumber = DateTime.Now.DayOfYear / 7;
            _viewmodel.Year = DateTime.Now.Year.ToString();
            LoadCalenderDetailsAsync();

            SetTimes();
            PopulateTimePlanCollectionsAsync();

            #region test data

            //_viewmodel.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday1Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });

            //_viewmodel.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });
            //_viewmodel.Weekday2Collection.Add(new EventElement() { Colors = new List<string>() { "Blue", "Red", "Yellow" } });

            #endregion

            UpdateObsCollection updater = new UpdateObsCollection();
            updater.GetEmployeesAsync(_viewmodel.Employees);
        }

        #region properties 

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
            _viewmodel.Headers.Clear();
            foreach (var date in GetDatesFromWeekNumber.GetDates(_viewmodel.WeekNumber))
            {
                _viewmodel.Headers.Add(date);
            }

            //Sætter år ud fra den første dato.
            //TODO gør at den finder år ud fra alle datoer og skriver 2 årstal på når vi er i ugen omkring årsskiftet.
            if (_viewmodel.Year != _viewmodel.Headers[1].Year.ToString())
            {
                _viewmodel.Year = _viewmodel.Headers[1].Year.ToString();
            }

            _employeePlacementIndex.Clear();

            SetTimes();
            await PopulateTimePlanCollectionsAsync();
            SetDaysAndDates();

        }

        /// <summary>
        /// Addere ugenummer med 1 og opdatere viewet med ny datoer og events.
        /// </summary>
        public void AddWeekNumber()
        {
            var t = _viewmodel.Day1Header.DayOfYear;
            DateTime nextWeek = _viewmodel.Day1Header;
            nextWeek = nextWeek.AddDays(7);
            _viewmodel.WeekNumber = nextWeek.DayOfYear / 7;
            LoadCalenderDetailsAsync();

        }

        /// <summary>
        /// Subtraktion af ugenummer med 1 og opdatere viewet med ny datoer og events.
        /// </summary>
        public void SubstractWeekNumber()
        {
            var t = _viewmodel.Day1Header.DayOfYear;
            DateTime nextWeek = _viewmodel.Day1Header;
            nextWeek = nextWeek.Subtract(TimeSpan.FromDays(7));
            _viewmodel.WeekNumber = nextWeek.DayOfYear / 7;
            LoadCalenderDetailsAsync();
        }

        #endregion

        #region Opdatering af viewet 

        /// <summary>
        /// Sætter alle headers med datoer fra headers collection
        /// </summary>
        public void SetDaysAndDates()
        {
            _viewmodel.Day1Header = _viewmodel.Headers[0];
            _viewmodel.Day2Header = _viewmodel.Headers[1];
            _viewmodel.Day3Header = _viewmodel.Headers[2];
            _viewmodel.Day4Header = _viewmodel.Headers[3];
            _viewmodel.Day5Header = _viewmodel.Headers[4];
            _viewmodel.Day6Header = _viewmodel.Headers[5];
            _viewmodel.Day7Header = _viewmodel.Headers[6];

        }

        /// <summary>
        /// Opdatere tiderne på viewet og i timePlanCollections
        /// </summary>
        /// <param name="intervalInMinutes"></param>
        public void SetTimes(int intervalInMinutes = 30)
        {
            _viewmodel.Times.Clear();
            _timePlanCollection1.Clear();
            _timePlanCollection2.Clear();
            _timePlanCollection3.Clear();
            _timePlanCollection4.Clear();
            _timePlanCollection5.Clear();
            _timePlanCollection6.Clear();
            _timePlanCollection7.Clear();

            for (double i = _starttime.TotalMinutes; i < _endtime.TotalMinutes; i += intervalInMinutes)
            {
                _viewmodel.Times.Add(TimeSpan.FromMinutes(i).ToString(@"hh\:mm"));
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
            _viewmodel.Weekday1Collection.Clear();
            _viewmodel.Weekday2Collection.Clear();
            _viewmodel.Weekday3Collection.Clear();
            _viewmodel.Weekday4Collection.Clear();
            _viewmodel.Weekday5Collection.Clear();
            _viewmodel.Weekday6Collection.Clear();
            _viewmodel.Weekday7Collection.Clear();

            int headerindex = 1;
            foreach (var header in _viewmodel.Headers)
            {

                switch (headerindex)
                {
                    case 1:
                        {
                            AddToView(_timePlanCollection1, _viewmodel.Weekday1Collection);
                            break;
                        }
                    case 2:
                        {
                            AddToView(_timePlanCollection2, _viewmodel.Weekday2Collection);
                            break;
                        }
                    case 3:
                        {
                            AddToView(_timePlanCollection3, _viewmodel.Weekday3Collection);
                            break;
                        }
                    case 4:
                        {
                            AddToView(_timePlanCollection4, _viewmodel.Weekday4Collection);
                            break;
                        }
                    case 5:
                        {
                            AddToView(_timePlanCollection5, _viewmodel.Weekday5Collection);
                            break;
                        }
                    case 6:
                        {
                            AddToView(_timePlanCollection6, _viewmodel.Weekday6Collection);
                            break;
                        }
                    case 7:
                        {
                            AddToView(_timePlanCollection7, _viewmodel.Weekday7Collection);
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
        private void AddToView(Dictionary<TimeSpan, TimeIntervalDetails> fromCollection,
            ObservableCollection<EventElement> collectionToUpdate)
        {
            foreach (TimeIntervalDetails tp in fromCollection.Values)
            {

                var e = new EventElement();
                if (tp.Update)
                {

                    // Vi matcher alle employees 

                    foreach (Employees employee in _employeePlacementIndex.GetEmployees())
                    {
                        Employees tempemployee = tp.GetMembers.Find(x => x.EmployeeID == employee.EmployeeID);

                        if (tempemployee != null)
                            e.Colors.Add(tp.GetWorktimeEventDetail(employee.EmployeeID));
                        else
                        {
                            e.Colors.Add(new WorktimeEventDetails("", "", 0));
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
        protected virtual async Task PopulateTimePlanCollectionsAsync()
        {
            int headerindex = 1;
            foreach (var header in _viewmodel.Headers)
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
                                await FindAndAddEmployeesToTimePlanAsync(_timePlanCollection2, worktime);
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
        protected async Task FindAndAddEmployeesToTimePlanAsync(Dictionary<TimeSpan, TimeIntervalDetails> collection,
            Worktimes worktime)
        {
            //først finder vi empluyee id på den employee som har worktimes
            var EmployeeCatalog = CatalogsSingleton.Instance.EmployeeCatalog;
            int id = worktime.EmployeeID;
            Employees emp = await EmployeeCatalog.GetSingleAsync(id.ToString());

            //Herefter kigger vi igennem alle tiderne og sætter employeen på når det svare til hans tidsplan.
            for (double i = worktime.TimeStart.TimeOfDay.TotalMinutes; i < worktime.TimeEnd.TimeOfDay.TotalMinutes; i += 30)
            {
                TimeSpan tFromWorktime = TimeSpan.FromMinutes(i);
                TimeSpan tTemp;


                while (tFromWorktime.Minutes < 30 && tFromWorktime.Minutes > 0)
                {
                    tFromWorktime = tFromWorktime.Subtract(new TimeSpan(0, 1, 0));
                }

                while (tFromWorktime.Minutes > 30)
                {
                    tFromWorktime = tFromWorktime.Subtract(new TimeSpan(0, 1, 0));
                }



                if (collection.ContainsKey(tFromWorktime))
                {
             
                    _employeePlacementIndex.AddEmployee(emp);
                    
                    var t1 = _employeePlacementIndex.GetEmployeeColor(emp.EmployeeID);
                    var t2 = emp.FirstName + " " + emp.LastName;
                    var t3 = worktime.WorkTimeID;
                    collection[tFromWorktime].AddMember(emp, new WorktimeEventDetails(
                        t1, t2, t3));
                }
            }
        }

        #endregion
    }
}