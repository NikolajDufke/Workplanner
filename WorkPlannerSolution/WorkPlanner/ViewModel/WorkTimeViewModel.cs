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
        private int _id;
        private string _name;
        private EmployeeInformations _employeeInformationProp;
        private DateTimeOffset _dateTime;
        private TimeSpan _time;
        private WorkTimeHandler _workTimeHandler;
        private static Worktimes _selectedworktime;
        private ICommand _selectedWorktimeCommand;

        public WorkTimeViewModel()
        {
            _workTimeHandler = new WorkTimeHandler(this );

            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            WorkTimeCreateCommand = new RelayCommand(_workTimeHandler.CreateWorkTime);
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public EmployeeInformations EmployeeInformationProp
        {
            set { _employeeInformationProp = value;}
            get { return _employeeInformationProp; }
        }

        public DateTimeOffset Date
        {
            set { _dateTime = value; }
            get { return _dateTime; }
        }

        public TimeSpan Time
        {
            set { _time = value; }
            get { return _time; }
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

        public ObservableCollection<EmployeeInformations> EmployeeInformations
        {
            get
            {
                return CatalogsSingleton.Instance.EmployeeInfoCatalog.GetAll;
            }
        }

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
    }
}