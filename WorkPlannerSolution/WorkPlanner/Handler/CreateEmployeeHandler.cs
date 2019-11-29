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
using Windows.UI.Xaml.Controls;
using WorkPlanner.Common;
 using WorkPlanner.Catalog;
 using WorkPlanner.Common;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    public class CreateEmployeeHandler
    {
        private CreateEmployeeViewModel _createEmployeeViewModel;

        public CreateEmployeeHandler(CreateEmployeeViewModel CreateEmployeevm)
        {
            _createEmployeeViewModel = CreateEmployeevm;
            this._createEmployeeViewModel = CreateEmployeevm;
        }

        public async void CreateEmployee()
        {
           EmployeeInformations employeeInformation = new EmployeeInformations();
           Users user = new Users();
           Employees employee = new Employees();

            PropertyPopulator<EmployeeInformations> ppEmployeeInformation = new PropertyPopulator<EmployeeInformations>();
            PropertyPopulator<Users> ppUsers = new PropertyPopulator<Users>();

            employeeInformation = ppEmployeeInformation.Populate(_createEmployeeViewModel.PropEmployeeInfoList.ToList(), new EmployeeInformations());
            user = ppUsers.Populate(_createEmployeeViewModel.PropUsersInfoList.ToList(), new Users());

            CatalogsSingleton catalog = CatalogsSingleton.Instance;
 
            Users generatedUser = await catalog.UsersCatalog.AddAsync(user);
            if (generatedUser.UserID != 0)
            {
                EmployeeInformations generatedEmployeeInformation = await catalog.EmployeeInfoCatalog.AddAsync(employeeInformation);
                 
                if (generatedEmployeeInformation.EInformationID != 0)
                {
                    Employees generaEmployee = await catalog.EmployeeCatalog.AddAsync(new Employees()
                    {
                        EInformationID = generatedEmployeeInformation.EInformationID,
                        UserID = generatedUser.UserID
                    });

                    if (generaEmployee.EInformationID != 0)
                    {
                        _createEmployeeViewModel.Message = "Bruger er blevet oprettet";
                        PopulatePrepInfo();
                    }
                    else
                    {
                        _createEmployeeViewModel.Message = "Bruger kunne ikke oprettes";
                    }
                }
                else
                {
                    _createEmployeeViewModel.Message = "Bruger kunne ikke oprettes";
                }
            }
            else
            {
                _createEmployeeViewModel.Message = "Bruger kunne ikke oprettes";
            }
        }

        public void PopulatePrepInfo()
        {
            _createEmployeeViewModel.PropEmployeeInfoList.Clear();
            _createEmployeeViewModel.PropUsersInfoList.Clear();

            foreach (var empProp in Factories.PropertyHelpersFactory<EmployeeInformations>.PropertyNamesFactory().GetListOfPropinfo)
            {
                _createEmployeeViewModel.PropEmployeeInfoList.Add(empProp);
            }

            foreach (var userProp in Factories.PropertyHelpersFactory<Users>.PropertyNamesFactory().GetListOfPropinfo)
            {
                _createEmployeeViewModel.PropUsersInfoList.Add(userProp);
            }

        }
    }
}
