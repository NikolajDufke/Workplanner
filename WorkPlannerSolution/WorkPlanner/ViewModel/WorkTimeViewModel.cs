using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class WorkTimeViewModel : ViewModelBase
    {
        #region Instance
        private int _id;
        private string _name;
        private Employees _employeeProp;
        private DateTimeOffset _dateTime;
        private TimeSpan _time1;
        private TimeSpan _time2;
        private WorkTimeHandler _workTimeHandler;
        private static Worktimes _selectedworktime;
        private ICommand _selectedWorktimeCommand;
        private string _message;
        #endregion

        #region Constructer
        public WorkTimeViewModel()
        {
            var T = CatalogsSingleton.Instance.EmployeeCatalog.GetAll;
            _workTimeHandler = new WorkTimeHandler(this);

            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, new TimeSpan());
            TimeStart = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            TimeEnd = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            WorkTimeCreateCommand = new RelayCommand(_workTimeHandler.CreateWorkTime);
        }
        #endregion

        #region Properties
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public Employees EmployeeProp
        {
            set { _employeeProp = value;}
            get { return _employeeProp; }
        }

        public DateTimeOffset Date
        {
            set { _dateTime = value; }
            get { return _dateTime; }
        }

        public TimeSpan TimeStart
        {
            set { _time1 = value; }
            get { return _time1; }
        }

        public TimeSpan TimeEnd
        {
            set { _time2 = value; }
            get { return _time2; }
        }

        public WorkTimeHandler Worktimeh
        {
            set { _workTimeHandler = value; }
            get { return _workTimeHandler; }
        }

        public static Worktimes SelectedWorktime
        {
            set { _selectedworktime = value; }
            get { return _selectedworktime; }
        }
        #endregion

        #region ObservableCollection
        public ObservableCollection<Employees> Employee
        {
            get
            {
                return new ObservableCollection<Employees>(CatalogsSingletons<Employees>.Instance.Catalog.GetAll);
            }
        }
        #endregion

        #region ICommands
        public ICommand SelectedWorktimeCommand
        {
            get
            {
                return _selectedWorktimeCommand ?? (_selectedWorktimeCommand =
                           new RelayArgCommand<Worktimes>(wt => _workTimeHandler.SetSelectedWorkTime(wt)));
            }
            set { _selectedWorktimeCommand = value; }
        }

        public ICommand WorkTimeCreateCommand { set; get; }
        #endregion

    }
}