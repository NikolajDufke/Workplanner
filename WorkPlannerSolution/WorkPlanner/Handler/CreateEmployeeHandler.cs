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
           Employees employee = new Employees();
           Users user = new Users();

            PropertyPopulator<Employees> ppEmployee = new PropertyPopulator<Employees>();
            PropertyPopulator<Users> ppUsers = new PropertyPopulator<Users>();

            employee = ppEmployee.Populate(_createEmployeeViewModel.PropEmployeeInfoList.ToList(), new Employees());
            user = ppUsers.Populate(_createEmployeeViewModel.PropUsersInfoList.ToList(), new Users());

            CatalogsSingleton catalog = CatalogsSingleton.Instance;
 
            Users generatedUser = await catalog.UsersCatalog.AddAsync(user);

            if (generatedUser.UserID != 0)
            {
                employee.UserID = generatedUser.UserID;

                Employees generatedEmployee = await catalog.EmployeeCatalog.AddAsync(employee);
                
                if (generatedEmployee.EmployeeID != 0)
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

        public void PopulatePrepInfo()
        {
            _createEmployeeViewModel.PropEmployeeInfoList.Clear();
            _createEmployeeViewModel.PropUsersInfoList.Clear();

            foreach (var empProp in Factories.PropertyHelpersFactory<Employees>.PropertyNamesFactory(new List<int>(){1, 9}).GetListOfPropinfo)
            {
                _createEmployeeViewModel.PropEmployeeInfoList.Add(empProp);
            }

            foreach (var userProp in Factories.PropertyHelpersFactory<Users>.PropertyNamesFactory(new List<int>(){1}).GetListOfPropinfo)
            {
                _createEmployeeViewModel.PropUsersInfoList.Add(userProp);
            }

        }
    }
}
