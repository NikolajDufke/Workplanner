﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
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

        private Employees SelectedEmp()
        {
            var allempinfolist = _catalogsSingleton.EmployeeCatalog.GetAll().Result;

            var selected = from empinfo in allempinfolist
                where empinfo.FirstName == "1" && empinfo.LastName == "1" && empinfo.City == "1" &&
                      empinfo.Adress == "1" && empinfo.Email == "1" && empinfo.PhoneNumber == 1 &&
                      empinfo.ZipPostal == 1
                select empinfo;
            
            return selected.Last();
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

            Employees empinfo = SelectedEmp();

            System.Threading.Thread.Sleep(5000);
            _catalogsSingleton.EmployeeCatalog.RemoveAsync(empinfo.EmployeeID.ToString());
            System.Threading.Thread.Sleep(5000);
            _catalogsSingleton.UsersCatalog.RemoveAsync(empinfo.UserID.ToString());
        }
    }
}
