using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkPlanner.Catalog;
using WorkPlanner.Converter;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;
using WorkPlanner.Handler;

namespace WorkPlannerUnitTests
{
    [TestClass]
    public class WorkTimeUnitTest
    {
        private WorkTimeViewModel _workTimeViewModel;
        private CatalogsSingleton _catalogsSingleton;
        

        public void Arrange()
        {
            _workTimeViewModel = new WorkTimeViewModel();
            _catalogsSingleton = CatalogsSingleton.Instance;
        }

        public void SetTestWorkTime()
        {

            DateTime now = DateTime.Now;
            _workTimeViewModel.Date = new DateTimeOffset(now);
            _workTimeViewModel.TimeStart = new TimeSpan(0, now.Hour, now.Minute, now.Second);
            _workTimeViewModel.TimeEnd = new TimeSpan(0, now.Hour+1, now.Minute, now.Second);
            Employees emp = _catalogsSingleton.EmployeeCatalog.GetAll().Result.First();
            if (emp != null && emp.EmployeeID != 0)
            {
                _workTimeViewModel.EmployeeProp = emp;
            }
            else 
            {
                throw new AssertFailedException("No employee found");
            }

            //return new Worktimes() { EmployeeID = 1, Date = new DateTime(2019, 11, 29), TimeStart = new DateTime(2019, 11, 29, 10, 30, 0), TimeEnd = new DateTime(2019, 11, 29, 12, 30, 0), WorkTimeID = 9 };
        }

        [TestMethod]
        public void TestAddWorkTime()
        {
            //Arrange
            Arrange();
            int expectedResult = _catalogsSingleton.WorktimeCatalog.GetAll().Result.Count + 1;
            SetTestWorkTime();

            //Act
            _workTimeViewModel.WorkTimeCreateCommand.Execute(null);
            System.Threading.Thread.Sleep(5000);
            int actual = _catalogsSingleton.WorktimeCatalog.GetAll().Result.Count;

            //await _catalogsSingleton.WorktimeCatalog.AddAsync(testWorktimes);

            ////Assert
            Assert.AreEqual(expectedResult, actual);

            //Cleanup
            var allworktimeList = _catalogsSingleton.WorktimeCatalog.GetAll().Result;

                DateTime timeEndFromViewmodel = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(_workTimeViewModel.Date, _workTimeViewModel.TimeEnd);
                DateTime timeStartFromViewmodel = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(_workTimeViewModel.Date, _workTimeViewModel.TimeStart);
                DateTime DateFromViewmodel = DateTimeConverter.DateTimeOffsetToDateTime(_workTimeViewModel.Date);

            foreach (var worktimes in allworktimeList)
            { 
                if (worktimes.TimeEnd == timeEndFromViewmodel && worktimes.TimeStart == timeStartFromViewmodel && worktimes.Date == DateFromViewmodel && worktimes.EmployeeID == 5002 )
                {
                    _catalogsSingleton.WorktimeCatalog.RemoveAsync(worktimes.WorkTimeID.ToString());
                }
            }
        }
    }
}
