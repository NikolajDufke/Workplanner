using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
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

        public async void CreateEmployee()
        {
            employeeInformation = new EmployeeInformation();
            user = new Users();
            employee = new Employee();

            PropertyPopulator<EmployeeInformation> ppEmployeeInformation = new PropertyPopulator<EmployeeInformation>();
            PropertyPopulator<Users> ppUsers = new PropertyPopulator<Users>();

            employeeInformation = ppEmployeeInformation.Populate(_createEmployeeViewModel.PropEmployeeInfoList.ToList(), new EmployeeInformation());
            user = ppUsers.Populate(_createEmployeeViewModel.PropUsersInfoList.ToList(), new Users());
 
            //employee.EmployeeInformation = employeeInformation;
            //employee.Users = user;

            var catalog = Catalog.CatalogsSingleton.Instance;

            Users generatedUser = await catalog.UsersCatalog.AddAsync(user);
            if (generatedUser != null)
            {
               
                EmployeeInformation generatedEmployeeInformation =
                    await catalog.EmployeeInfoCatalog.AddAsync(employeeInformation);

                if (generatedEmployeeInformation != null)
                {
                    Employee generaEmployee = await catalog.EmployeeCatalog.AddAsync(new Employee()
                    {
                        EInformationID = generatedEmployeeInformation.EInformationID,
                        UserID = generatedUser.UserID
                    });
              
                    _createEmployeeViewModel.PopulatePrepInfo();
                     
                }
                _createEmployeeViewModel.Message = "Bruger kunne ikke oprettes";
            }

            _createEmployeeViewModel.Message = "Bruger kunne ikke oprettes";


        }
    }
}
