using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using WorkPlanner.Common;
using WorkPlanner.Handler;
using WorkPlanner.Interface;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class CalendarViewModelBase: ViewModelBase 
    {
        private string _year;
        private ObservableCollection<EventElement> _weekday1Collection;
        private ObservableCollection<EventElement> _weekday2Collection;
        private ObservableCollection<EventElement> _weekday3Collection;
        private ObservableCollection<EventElement> _weekday4Collection;
        private ObservableCollection<EventElement> _weekday5Collection;
        private ObservableCollection<EventElement> _weekday6Collection;
        private ObservableCollection<EventElement> _weekday7Collection;
        protected ICalenderHandler _handlerCal;
        private ObservableCollection<string> _times;
        private ObservableCollection<DateTime> _headers;
        private DateTime _day1Header;
        private DateTime _day2Header;
        private DateTime _day3Header;
        private DateTime _day4Header;
        private DateTime _day5Header;
        private DateTime _day6Header;
        private DateTime _day7Header;

        private ICommand _nextWeekCommand;
        private ICommand _previousWeekCommand;
        private ObservableCollection<Employees> _employees;
        private ObservableCollection<WorktimeEventDetails> _worktimeEventDetails;


        public CalendarViewModelBase()
        {
           
            _headers = new ObservableCollection<DateTime>();
            _weekday1Collection = new ObservableCollection<EventElement>();
            _weekday2Collection = new ObservableCollection<EventElement>();
            _weekday3Collection = new ObservableCollection<EventElement>();
            _weekday4Collection = new ObservableCollection<EventElement>();
            _weekday5Collection = new ObservableCollection<EventElement>();
            _weekday6Collection = new ObservableCollection<EventElement>();
            _weekday7Collection = new ObservableCollection<EventElement>();
            _times = new ObservableCollection<string>();
            _employees = new ObservableCollection<Employees>();
        }

        #region General
        public ObservableCollection<WorktimeEventDetails> WorktimeEventDetails
        {
            get { return _worktimeEventDetails; }
            set { _worktimeEventDetails = value; }
        }


        public ObservableCollection<Employees> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public ObservableCollection<DateTime> Headers
        {
            get { return _headers; }
            set { _headers = value; }
        }

        private int _weekNumber;

        public ObservableCollection<string> Times
        {
            get { return _times; }
            set
            {
                _times = value;
                OnPropertyChanged();
            }
        }

        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }


        public int WeekNumber
        {
            get { return _weekNumber; }
            set
            {
                _weekNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Headers

        public DateTime Day1Header
        {
            get { return _day1Header; }
            set
            {
                _day1Header = value;
                OnPropertyChanged();
            }
        }

        public DateTime Day2Header
        {
            get { return _day2Header; }
            set
            {
                _day2Header = value;
                OnPropertyChanged();
            }
        }

        public DateTime Day3Header
        {
            get { return _day3Header; }
            set
            {
                _day3Header = value;
                OnPropertyChanged();
            }
        }

        public DateTime Day4Header
        {
            get { return _day4Header; }
            set
            {
                _day4Header = value;
                OnPropertyChanged();
            }
        }

        public DateTime Day5Header
        {
            get { return _day5Header; }
            set
            {
                _day5Header = value;
                OnPropertyChanged();
            }
        }

        public DateTime Day6Header
        {
            get { return _day6Header; }
            set
            {
                _day6Header = value;
                OnPropertyChanged();
            }
        }

        public DateTime Day7Header
        {
            get { return _day7Header; }
            set
            {
                _day7Header = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region WeekDayCollections

        public ObservableCollection<EventElement> Weekday1Collection
        {
            get { return _weekday1Collection; }
            set
            {
                _weekday1Collection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EventElement> Weekday2Collection
        {
            get { return _weekday2Collection; }
            set
            {
                _weekday2Collection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EventElement> Weekday3Collection
        {
            get { return _weekday3Collection; }
            set
            {
                _weekday3Collection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EventElement> Weekday4Collection
        {
            get { return _weekday4Collection; }
            set
            {
                _weekday4Collection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EventElement> Weekday5Collection
        {
            get { return _weekday5Collection; }
            set
            {
                _weekday5Collection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EventElement> Weekday6Collection
        {
            get { return _weekday6Collection; }
            set
            {
                _weekday6Collection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EventElement> Weekday7Collection
        {
            get { return _weekday7Collection; }
            set
            {
                _weekday7Collection = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand NextWeekCommand
        {
            get
            {
                return _nextWeekCommand ??
                       (_nextWeekCommand = new RelayCommand(_handlerCal.AddWeekNumber));
            }
            set { _nextWeekCommand = value; }
        }

        public ICommand PreviousWeekCommand
        {
            get
            {
                return _previousWeekCommand ??
                       (_previousWeekCommand = new RelayCommand(_handlerCal.SubstractWeekNumber));
            }
            set { _previousWeekCommand = value; }
        }

        #endregion
    }
}