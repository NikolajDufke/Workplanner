using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using WorkPlanner.Catalog;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class EmployeePageViewModel : CalendarViewModelBase
    {
        
        #region Instace fields
        private ObservableCollection<PropInfo> _propEmployeeInfoList;
        private Handler.EmployeePageHandler _EmployeePageHandler;
       
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

        private Employees _activeUser;

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
    }
}