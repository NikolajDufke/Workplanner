using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkPlanner.ViewModel;
using WorkPlanner.Model;
using WorkPlanner.Handler;

namespace WorkPlannerUnitTests
{
    [TestClass]
    class CreateEmployeeTest
    {
        private CreateEmployeeViewModel _createEmployeeViewModel;
        private CreateEmployeeHandler _createEmployeeHandler;

        public CreateEmployeeTest()
        {
            _createEmployeeViewModel = null;
            _createEmployeeHandler = null;
        }

        private void Arrange()
        {
            _createEmployeeViewModel = new CreateEmployeeViewModel();
            _createEmployeeHandler = new CreateEmployeeHandler(_createEmployeeViewModel);
            ObservableCollection<PropInfo> propemployeeCollection = new ObservableCollection<PropInfo>();
            ObservableCollection<PropInfo> propuserCollection = new ObservableCollection<PropInfo>();

        }

        [TestMethod]
        public void TestCreateEmployee()
        {
            _createEmployeeHandler.CreateEmployee();
        }
    }
}
