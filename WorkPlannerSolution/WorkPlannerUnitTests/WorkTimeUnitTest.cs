using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkPlanner.Catalog;
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
        }

        public Worktimes SetTestWorkTime()
        {


           _workTimeViewModel.TimeEnd = new TimeSpan(DateTime.Now.Year,);

           _workTimeViewModel.TimeStart = new TimeSpan( 11, 29, 0);
           _workTimeViewModel.TimeEnd = new DateTime(2019, 11, 29, 12, 30, 0);

            return new Worktimes() { EmployeeID = 1, Date = new DateTime(2019, 11, 29), TimeStart = new DateTime(2019, 11, 29, 10, 30, 0), TimeEnd = new DateTime(2019, 11, 29, 12, 30, 0), WorkTimeID = 9 };
        }

        [TestMethod]
        public void TestAddWorkTime()
        {
            //Arrange
            Arrange();
            int startvalue = _catalogsSingleton.WorktimeCatalog.GetAll().Result.Count;
            Worktimes testWorktimes = GetTestWorkTime();


            //Act
            _workTimeViewModel.WorkTimeCreateCommand.Execute(null);

            //await _catalogsSingleton.WorktimeCatalog.AddAsync(testWorktimes);

            ////Assert
            Assert.AreEqual(startvalue + 1, _catalogsSingleton.WorktimeCatalog.GetAll().Result);

            //Cleanup
            _catalogsSingleton.WorktimeCatalog.RemoveAsync(testWorktimes.WorkTimeID.ToString());
        }
    }
}