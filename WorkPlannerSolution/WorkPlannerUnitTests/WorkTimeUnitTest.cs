using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkPlanner.Catalog;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;

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
            return new Worktimes();
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
            _catalogsSingleton.WorktimeCatalog.RemoveAsync(testWorktimes.ToString());
        }
    }
}