using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
            _EmployeePageHandler = new EmployeePageHandler(this);
            _propEmployeeInfoList = new ObservableCollection<PropInfo>();
            _EmployeePageHandler.PopulatePrepInfo();

        }

        //public Employees EmployeeProp
        //{
        //    set { _employeeProp = value; }
        //    get { return _employeeProp; }
        //}

        #region Observablecollections
        public ObservableCollection<PropInfo> PropEmployeeInfoList
        {
            get { return _propEmployeeInfoList; }
            set { _propEmployeeInfoList = value; }
        }

        #endregion
    }
}