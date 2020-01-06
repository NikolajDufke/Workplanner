using System;
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
    public class EmployeePageViewModel : CalendarViewModelBase
    {
        
        #region Instace fields
        private ObservableCollection<PropInfo> _propEmployeeInfoList;
        private Handler.EmployeePageHandler _EmployeePageHandler;
        private TimeSpan _overTimeThisMonth;
        private TimeSpan _overTimeThisWeek;
        private Employees _activeUser;

        private ICommand _hamburgerButton_CheckedCommand;
        private ICommand _navigateToMainPageCommand;
        private ICommand _nagigateToAdminCommand;
        private ICommand _logoutUser;
        //private Employees _employeeProp;
        #endregion

        public EmployeePageViewModel()
        {
            _activeUser = EmployeesSingleton.Instance.EmployeesObject;
            _propEmployeeInfoList = new ObservableCollection<PropInfo>();
            _EmployeePageHandler = new EmployeePageHandler(this);
            _handlerCal = _EmployeePageHandler;
            _EmployeePageHandler.LoadCalenderDetailsAsync();
        }

        public TimeSpan OverTimeThisWeek
        {
            get { return _overTimeThisWeek; }
            set { _overTimeThisWeek = value; }
        }

        public TimeSpan OverTimeThisMonth
        {
            get { return _overTimeThisMonth;}
            set { _overTimeThisMonth = value; }
        }

        public Employees ActiveUser
        {
            get { return _activeUser; }
            set { _activeUser = value; }
        }

        #region Observablecollections
        public ObservableCollection<PropInfo> PropEmployeeInfoList
        {
            get { return _propEmployeeInfoList; }
            set { _propEmployeeInfoList = value; }
        }

        #endregion


        #region Menu

        private bool _hamburgerButton_Checked;

        public ICommand HamburgerButton_CheckedCommand
        {
            get
            {
                return _hamburgerButton_CheckedCommand ??
                       (_hamburgerButton_CheckedCommand =
                           new RelayCommand(_EmployeePageHandler.HamburgerButton_Checked));
            }
            set { _hamburgerButton_CheckedCommand = value; }

        }

        public ICommand NavigateToMainPageCommand
        {
            get
            {
                return _navigateToMainPageCommand ??
                       (_navigateToMainPageCommand =
                           new RelayCommand(_EmployeePageHandler.NavigateToMainPage));
            }
            set { _navigateToMainPageCommand = value; }

        }

        public ICommand NagigateToAdminCommand
        {
            get
            {
                return _nagigateToAdminCommand ??
                       (_nagigateToAdminCommand =
                           new RelayCommand(_EmployeePageHandler.NavigateToAdmin));
            }
            set { _nagigateToAdminCommand = value; }

        }

        public ICommand LogoutUser
        {
            get
            {
                return _logoutUser ??
                       (_logoutUser =
                           new RelayCommand(ChangePage.Logout));
            }
            set { _logoutUser = value; }

        }

        private bool _isPaneOpen;

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set
            {
                _isPaneOpen = value;
                OnPropertyChanged();
            }
        }


        #endregion
    }
}