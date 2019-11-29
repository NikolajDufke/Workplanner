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

        public Worktimes GetTestWorkTime()
        {
            return new Worktimes(){EInformationID = 1, Date = new DateTime(2019, 11, 29), TimeStart = new DateTime(2019, 11, 29, 10, 30,0), TimeEnd = new DateTime(2019, 11, 29, 12, 30, 0) };
        }

        [TestMethod]
        public async void TestAddWorkTime()
        {
            //Arrange
            Arrange();
            int startvalue = _catalogsSingleton.WorktimeCatalog.GetAll.Count;
            Worktimes testWorktimes = GetTestWorkTime();

            //Act
            await _catalogsSingleton.WorktimeCatalog.AddAsync(testWorktimes);

            //Assert
            Assert.AreEqual(startvalue + 1, _catalogsSingleton.WorktimeCatalog.GetAll.Count);

            //Cleanup
            _catalogsSingleton.WorktimeCatalog.RemoveAsync(testWorktimes.WorkTimeID.ToString());
        }
    }
}