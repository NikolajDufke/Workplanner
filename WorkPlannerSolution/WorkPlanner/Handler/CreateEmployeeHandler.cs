using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using WorkPlanner.Common;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    class CreateEmployeeHandler
    {
        private CreateEmployeeViewModel _createEmployeeViewModel;

        private Employee employee;
        private Users user;
        private EmployeeInformation employeeInformation;

        public CreateEmployeeHandler(CreateEmployeeViewModel CreateEmployeevm)
        {
            _createEmployeeViewModel = CreateEmployeevm;
            this._createEmployeeViewModel = CreateEmployeevm;
        }

        public void CreateEmployee()
        {
            employeeInformation = new EmployeeInformation();
            user = new Users();
            employee = new Employee();

            PropertyPopulator<EmployeeInformation> ppEmployeeInformation = new PropertyPopulator<EmployeeInformation>();
            PropertyPopulator<Users> ppUsers = new PropertyPopulator<Users>();

            employeeInformation = ppEmployeeInformation.Populate(_createEmployeeViewModel.PropEmployeeInfoList.ToList(), new EmployeeInformation());
            user = ppUsers.Populate(_createEmployeeViewModel.PropUsersInfoList.ToList(), new Users());
 
            employee.EmployeeInformation = employeeInformation;
            employee.Users = user;

            var catalogEmployee = Catalog.CatalogsSingleton.Instance;

            catalogEmployee.EmployeeCatalog.AddAsync(employee);
        }
    }
}
