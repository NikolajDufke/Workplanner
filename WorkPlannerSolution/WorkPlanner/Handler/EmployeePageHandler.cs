using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Model;
using WorkPlanner.Proxy;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    public class EmployeePageHandler : CalendarHandler<EmployeePageViewModel>
    {
        #region Instace fields
        private EmployeePageViewModel _employeePageViewModel;
        #endregion

        public EmployeePageHandler(EmployeePageViewModel EmployeePageVM) : base(EmployeePageVM)
        {
            _employeePageViewModel = EmployeePageVM;
        }


        #region Methods

        public void PopulatePrepInfo()
        {
            _employeePageViewModel.PropEmployeeInfoList.Clear();

            foreach (var empProp in Factories.PropertyHelpersFactory<Employees>.PropertyNamesFactory(new List<int>() { 1, 9 }).GetListOfPropinfo)
            {
                _employeePageViewModel.PropEmployeeInfoList.Add(empProp);
            }

        }
        #endregion
    }
}