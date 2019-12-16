using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class AdminPageViewModel : CalendarViewModelBase
    {

        private int _selectedWorktime;
        private Employees _selectedEmployee;
        private Visibility _employeeVisibility;
        private AdminHandler _handler;


        private ObservableCollection<DateTime> _headers;
        private ObservableCollection<Employees> _employees;
        private ObservableCollection<WorktimeEventDetails> _worktimeEventDetails;

        private ICommand _deleteWorktimeCommand;
        private ICommand _changeVisibility;
        private ICommand _deleteEmployeeCommand;
        private ICommand _setSelectedWorktimeCommand;

        public AdminPageViewModel()
        {

            _employees = new ObservableCollection<Employees>();
            _worktimeEventDetails = new ObservableCollection<WorktimeEventDetails>();

            _handler = new AdminHandler(this);
            _handlerCal = _handler;
            _handlerCal.LoadCalenderDetailsAsync();
            _employeeVisibility = Visibility.Collapsed;
        
        }

        #region General


        public int SelectedWorktime
        {
            get { return _selectedWorktime; }
            set
            {
                _selectedWorktime = value;
                OnPropertyChanged();
            }
        }

        public Employees SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

      

#endregion

        #region General

  


        public ObservableCollection<Employees> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }



        /// <summary>
        /// Property som grid i viewet er bundet til om, gridet er synligt/usynligt og ændrer property hvis der bliver trykket på "open" knappen.
        /// </summary>

        public Visibility EmployeeVisibility
        {
            get { return _employeeVisibility; }
            set
            {
                _employeeVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

 

    

        #region Commands

        public ICommand SetSelectedWorktimeCommand
        {
            get
            {
                return _setSelectedWorktimeCommand ?? (_setSelectedWorktimeCommand =
                           new RelayArgCommand<int>(ev => _handler.SetSelectedWorktime(ev)));
            }
        }

        /// <summary>
        /// ICommand, som kører metoden ChangeEmployeeVisibility i AdminHandler når man trykker på "open" knappen i viewet.
        /// </summary>

        public ICommand ChangeVisibility
        {
            get
            {
                return _changeVisibility ?? (_changeVisibility = new RelayCommand(_handler.ChangeEmployeeVisibility));
            }
            set { _changeVisibility = value; }
        }

        public ICommand DeleteEmployeeCommand
        {
            get { return _deleteEmployeeCommand ?? (_deleteEmployeeCommand = new RelayCommand(_handler.DeleteEmployee)); }
            set { _deleteEmployeeCommand = value; }
        }

        public ICommand DeleteWorktimeCommand
        {
            get { return _deleteWorktimeCommand ?? (_deleteWorktimeCommand = new RelayCommand(_handler.DeleteWorktime)); }
            set { _deleteWorktimeCommand = value; }
        }
        #endregion
    }
}
