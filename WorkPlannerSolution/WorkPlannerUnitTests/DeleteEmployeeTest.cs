using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkPlanner.Catalog;
using WorkPlanner.ViewModel;

namespace WorkPlannerUnitTests
{
    [TestClass]
    public class DeleteEmployeeTest
    {
        private AdminPageViewModel _AdminPageVM;
        private CatalogsSingleton _catalogsSingleton;

        private void Arrange()
        {
            _AdminPageVM = new AdminPageViewModel();
            _catalogsSingleton = CatalogsSingleton.Instance;

        }

        [TestMethod]
        public void TestDeleteEmployee()
        {
            //Arrange
            Arrange();
            int startValue = _catalogsSingleton.EmployeeCatalog.GetAll().Result.Count;
            int expectedValue = _catalogsSingleton.EmployeeCatalog.GetAll().Result.Count - 1;
            
            //Act
            _AdminPageVM.DeleteEmployeeCommand.Execute(null);
            int actualValue = _catalogsSingleton.EmployeeCatalog.GetAll().Result.Count;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestMethod()
        {
            //Arrange
            int result = 1;
            int expectedresult = result - 1;

            //Act
            result = result - 1;

            //Assert
            Assert.AreEqual(expectedresult, result);
        }

    }
}
