using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Model;
using WorkPlanner.Proxy;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    public class AdminHandler : CalendarHandler<AdminPageViewModel>
    {
        private CatalogsSingleton _catalog;
        private AdminPageViewModel _vm;
        private UpdateObsCollection _updater;


        public AdminHandler(AdminPageViewModel ViewModel) : base(ViewModel)
        {
            _catalog = CatalogsSingleton.Instance;
   
            _vm = ViewModel;

            _updater = new UpdateObsCollection();
            _updater.GetEmployeesAsync(_vm.Employees);
        }

        #region Methods
        public void SetSelectedWorktime(int id)
        {
            _vm.SelectedWorktime = id;
        }

        /// <summary>
        /// En metode som ændrer synligheden på et grid i vores view
        /// Metoden bruger viewmodellens property - EmployeeVisibility
        /// </summary>
        #region Visibility
        public void ChangeEmployeeVisibility()
        {

            if (_vm.EmployeeVisibility == Visibility.Collapsed)
            {
                _vm.EmployeeVisibility = Visibility.Visible;
                _updater.GetEmployeesAsync(_vm.Employees);

            }
            else
            {
                _vm.EmployeeVisibility = Visibility.Collapsed;
            }
        }

        public async void DeleteEmployee()
        {
            if (_vm.SelectedEmployee != null)
            {
                List<Worktimes> toRemoveWorktimes = _catalogInterface.GetAllWorktimesByEmployee(_vm.SelectedEmployee);

                foreach (Worktimes worktime in toRemoveWorktimes)
                {
                    await _catalog.WorktimeCatalog.RemoveAsync(worktime.WorkTimeID.ToString());
                }
                await _catalog.EmployeeCatalog.RemoveAsync(_vm.SelectedEmployee.EmployeeID.ToString());
                await _catalogInterface.Reload();
                LoadCalenderDetailsAsync();
                _updater.GetEmployeesAsync(_vm.Employees);
            }
        }

        public async void DeleteWorktime()
        {
            if (_vm.SelectedWorktime != 0)
            {
                await _catalog.WorktimeCatalog.RemoveAsync(_vm.SelectedWorktime.ToString());
                await _catalogInterface.Reload();
                LoadCalenderDetailsAsync();
            }
        }
        #endregion




   

 



    
#endregion
    }
}
