using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkPlanner.Catalog;
using WorkPlanner.Handler;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;


namespace WorkPlannerUnitTests
{
    [TestClass]
    public class CreateEmployeeTest
    {

        private CreateEmployeeViewModel _createEmployeeViewModel;
        private CatalogsSingleton _catalogsSingleton;

        private void Arrange()
        {
            _createEmployeeViewModel = new CreateEmployeeViewModel();
            _catalogsSingleton = CatalogsSingleton.Instance;
            fillpropinfolist(_createEmployeeViewModel.PropEmployeeInfoList);
            fillpropinfolist(_createEmployeeViewModel.PropUsersInfoList);
        }

        private void fillpropinfolist(ObservableCollection<PropInfo> propinfolist)
        {
            foreach (PropInfo propinfo in propinfolist)
            {
                propinfo.ValueFromUser = "1";
            }
        }

        //[TestMethod]
        //public void TestCreateEmployee()
        //{
        //    //Arrange
        //    Arrange();
        //    int expectedresult = _catalogsSingleton.EmployeeInfoCatalog.GetAll.Count + 1;


        //    //Act
        //    _createEmployeeViewModel.CreateEmployeeCommand.Execute(null);


        //    //Assert
        //    Assert.AreEqual(expectedresult, _catalogsSingleton.EmployeeInfoCatalog.GetAll.Count);

        //    //Cleanup
        //    var allempinfolist = _catalogsSingleton.EmployeeInfoCatalog.GetAll;
        //    foreach (var empinfo in allempinfolist)
        //    {
        //        if (empinfo.FirstName == "1" && empinfo.LastName == "1" && empinfo.City == "1" && empinfo.Adress == "1" && empinfo.Email == "1" && empinfo.PhoneNumber == 1 && empinfo.ZipPostal == 1)
        //        {
        //           _catalogsSingleton.EmployeeInfoCatalog.RemoveAsync(empinfo.EInformationID.ToString());  
        //        }
        //        else
        //        {
        //            throw new Exception("Not Deleted!");
        //        }
        //    }
        //}

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
    }
}
