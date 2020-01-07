using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation.Peers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkPlanner.Catalog;
using WorkPlanner.Handler;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;


namespace WorkPlannerUnitTests
{
    [TestClass]
    public class EmployeeTest
    {

        private CreateEmployeeViewModel _createEmployeeViewModel;
        private CatalogsSingleton _catalogsSingleton;
        private AdminPageViewModel _AdminPageVM;

        private void Arrange()
        {
            _createEmployeeViewModel = new CreateEmployeeViewModel();
            _catalogsSingleton = CatalogsSingleton.Instance;
            fillpropinfolist(_createEmployeeViewModel.PropEmployeeInfoList);
            fillpropinfolist(_createEmployeeViewModel.PropUsersInfoList);
            _AdminPageVM = new AdminPageViewModel();
        }

        private void fillpropinfolist(ObservableCollection<PropInfo> propinfolist)
        {
            foreach (PropInfo propinfo in propinfolist)
            {
                propinfo.ValueFromUser = "1";
            }
        }

        [TestMethod]
        public void TestCreateEmployee()
        {
            //Arrange
            Arrange();
            int expectedresult = _catalogsSingleton.EmployeeCatalog.GetAll().Result.Count + 1;

            //Act
            _createEmployeeViewModel.CreateEmployeeCommand.Execute(null);
            System.Threading.Thread.Sleep(5000);
            int actual = _catalogsSingleton.EmployeeCatalog.GetAll().Result.Count;

            //Assert
            Assert.AreEqual(expectedresult, actual);

            //Cleanup
            var allempinfolist = _catalogsSingleton.EmployeeCatalog.GetAll().Result;
            foreach (var empinfo in allempinfolist)
            {
                if (empinfo.FirstName == "1" && empinfo.LastName == "1" && empinfo.City == "1" && empinfo.Adress == "1" && empinfo.Email == "1" && empinfo.PhoneNumber == 1 && empinfo.ZipPostal == 1)
                {
                    _catalogsSingleton.EmployeeCatalog.RemoveAsync(empinfo.EmployeeID.ToString());
                }
            }
        }

        [TestMethod]
        public void TestMethod()
        {
            //Arrange
            int result = 1;
            int expectedresult = result + 1;

            //Act
            result = result + 1;

            //Assert
            Assert.AreEqual(expectedresult, result);
        }

        [TestMethod]
        public void DeleteEmployeeTest()
        {
            //Arrange
            Arrange();
            int expectedValue = CatalogsSingleton.Instance.EmployeeCatalog.GetAll().Result.Count;
            _createEmployeeViewModel.CreateEmployeeCommand.Execute(null);


            //Act
            var allempinfolist = _catalogsSingleton.EmployeeCatalog.GetAll().Result;
            allempinfolist.Where(empinfo => e.FirstName == "1");
            var selected = from empinfo in allempinfolist
                where empinfo.FirstName == "1" && empinfo.LastName == "1" && empinfo.City == "1" &&
                      empinfo.Adress == "1" && empinfo.Email == "1" && empinfo.PhoneNumber == 1 &&
                      empinfo.ZipPostal == 1
                select empinfo;

            foreach (var empinfo in allempinfolist)
            {
                if (empinfo.FirstName == "1" && empinfo.LastName == "1" && empinfo.City == "1" && empinfo.Adress == "1" && empinfo.Email == "1" && empinfo.PhoneNumber == 1 && empinfo.ZipPostal == 1)
                {
                    _AdminPageVM.SelectedEmployee = empinfo;
                }
            }
            _AdminPageVM.DeleteEmployeeCommand.Execute(null);


            //Assert
        }
    }
}
