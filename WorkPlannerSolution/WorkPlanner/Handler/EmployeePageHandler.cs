using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Model;
using WorkPlanner.Proxy;
using WorkPlanner.ViewModel;
using WorkPlanner.Catalog;
using WorkPlanner.Model;
using WorkPlanner.View;

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
            GetOverTime();
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

        public void GetOverTime()
        {

            TimeSpan overtimeThisWeek = new TimeSpan();
            TimeSpan overTimeThisMonth = new TimeSpan();

           List<Worktimes> allWorktimesThisMonth = _catalogInterface.GetAllWorktimesByEmployee(_employeePageViewModel.ActiveUser).FindAll(x => x.Date.Year == DateTime.Now.Year && x.Date.Month == DateTime.Now.Month);

           foreach (Worktimes worktime in allWorktimesThisMonth)
           {
               var resultCalculator = OverTimeCalculator(worktime);

               if (resultCalculator != null)
               {
                   if (worktime.Date > DateTime.Now.Subtract(new TimeSpan(7, 0, 0)))
                   {
                       overtimeThisWeek = overtimeThisWeek.Add(resultCalculator.Value);
                   }

                   overTimeThisMonth = overTimeThisMonth.Add(resultCalculator.Value);
                }
           }

           _employeePageViewModel.OverTimeThisMonth = overTimeThisMonth;
           _employeePageViewModel.OverTimeThisWeek = overtimeThisWeek;

        }

        private Nullable<TimeSpan> OverTimeCalculator(Worktimes worktime)
        {
            Nullable<TimeSpan> result = null;

            if (worktime.CheckOut != null && worktime.TimeEnd < worktime.CheckOut)
            {
               result = worktime.CheckOut - worktime.TimeEnd;
            }

            return result;
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
                List<Worktimes> WorktimesThisDay = _catalogInterface.WorktimeForEmployeeOnSingleDay(header.Date, _employeePageViewModel.ActiveUser);

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


        public void HamburgerButton_Checked()
        {
            _employeePageViewModel.IsPaneOpen = !_employeePageViewModel.IsPaneOpen;
        }

        public void NavigateToMainPage()
        {
            Frame frame = new Frame();
            frame.Navigate(typeof(MainPage));
            Window.Current.Content = frame;
            Window.Current.Activate();
        }

        public void NavigateToAdmin()
        {
            Frame frame = new Frame();
            frame.Navigate(typeof(LoginPage));
            Window.Current.Content = frame;
            Window.Current.Activate();
        }

    }
}