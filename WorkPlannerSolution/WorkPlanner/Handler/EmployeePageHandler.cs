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

        /// <summary>
        /// Her tiltøjer vi timePlanCollections til viewet.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="worktime"></param>
        /// <returns></returns>
        protected override async Task FindAndAddEmployeesToTimePlanAsync(Dictionary<TimeSpan, TimeIntervalDetails> collection,
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