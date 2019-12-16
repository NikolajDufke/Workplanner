using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
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
            PropertyPopulator<Employees> ppEmployee = new PropertyPopulator<Employees>();
            PopulatePrepInfo();
            ppEmployee.Repopulate(EmployeePageVM.PropEmployeeInfoList, EmployeePageVM.ActiveUser);
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

        ///// <summary>
        ///// Her tiltøjer vi timePlanCollections til viewet.
        ///// </summary>
        ///// <param name="collection"></param>
        ///// <param name="worktime"></param>
        ///// <returns></returns>
        //protected override async Task FindAndAddEmployeesToTimePlanAsync(Dictionary<TimeSpan, TimeIntervalDetails> collection,
        //    Worktimes worktime)
        //{
        //    //først finder vi empluyee id på den employee som har worktimes
        //    var EmployeeCatalog = CatalogsSingleton.Instance.EmployeeCatalog;
        //    int id = worktime.EmployeeID;
        //    Employees emp = await EmployeeCatalog.GetSingleAsync(id.ToString());

        //    //Herefter kigger vi igennem alle tiderne og sætter employeen på når det svare til hans tidsplan.
        //    for (double i = worktime.TimeStart.TimeOfDay.TotalMinutes; i < worktime.TimeEnd.TimeOfDay.TotalMinutes; i += 30)
        //    {
        //        TimeSpan tFromWorktime = TimeSpan.FromMinutes(i);
        //        TimeSpan tTemp;


        //        while (tFromWorktime.Minutes < 30 && tFromWorktime.Minutes > 0)
        //        {
        //            tFromWorktime = tFromWorktime.Subtract(new TimeSpan(0, 1, 0));
        //        }

        //        while (tFromWorktime.Minutes > 30)
        //        {
        //            tFromWorktime = tFromWorktime.Subtract(new TimeSpan(0, 1, 0));
        //        }



        //        if (collection.ContainsKey(tFromWorktime))
        //        {
        //            _employeePlacementIndex.AddEmployee(emp);

        //            var t1 = _employeePlacementIndex.GetEmployeeColor(emp.EmployeeID);
        //            var t2 = emp.FirstName + " " + emp.LastName;
        //            var t3 = worktime.WorkTimeID;
        //            collection[tFromWorktime].AddMember(emp, new WorktimeEventDetails(
        //                t1, t2, t3));
        //        }
        //    }
        //}

        /// <summary>
        /// Finder worktimes i Databasen og sætter dem ind i TimeplanColletions.
        /// </summary>
        /// <returns></returns>
        protected override async Task PopulateTimePlanCollectionsAsync()
        {
            int headerindex = 1;
            foreach (var header in _viewmodel.Headers)
            {
                //Her finder vi alle worktimes som er på en given dag.
                List<Worktimes> WorktimesThisDay = _catalogInterface.WorktimeForEmployeeOnSingleDay(header.Date, _viewmodel.ActiveUser);

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
        #endregion
    }
}