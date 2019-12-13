using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;
using WorkPlanner.Catalog;
using WorkPlanner.Model;
using WorkPlanner.View;
using WorkPlanner.ViewModel;
using WorkPlanner.Common;

namespace WorkPlanner.Handler
{
    class LoginHandler
    {
        #region Instace fields
        private LoginPageViewModel _loginPageViewModel;
        private Users _selUser;
        private CatalogsSingleton _catalog;
        private EmployeesSingleton _employeesSingleton;
        #endregion
        #region Constructor
        public LoginHandler(LoginPageViewModel loginpageevm)
        {
            _loginPageViewModel = loginpageevm;
            this._loginPageViewModel = loginpageevm;
            _catalog = CatalogsSingleton.Instance;
            _employeesSingleton = EmployeesSingleton.Instance;
            var employeeCatalog = _catalog.EmployeeCatalog.GetAll();
            var worktimeCatalog = _catalog.WorktimeCatalog.GetAll();
            RemoveEmployeeWithoutUser();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Gets User from selEmployee.userid in LoginView compares it with UserID from Users from Database
        /// Checks AccessLevel and goes to the view you want.
        /// else updates messages to LoginView
        /// </summary>
        public async void LoginUser()
        {
            try
            {
                _selUser = await CatalogsSingleton.Instance.UsersCatalog.GetSingleAsync(
                    Convert.ToString(_loginPageViewModel.SelEmployees.UserID));
                if (_selUser.UserPassword == _loginPageViewModel.Password)
                {

                    _employeesSingleton.EmployeesObject = _loginPageViewModel.SelEmployees;
                    if (_selUser.AccessLevel == 1)
                    {
                        Frame frame = new Frame();
                        frame.Navigate(typeof(AdminPage));
                        Window.Current.Content = frame;
                        Window.Current.Activate();
                    }
                    else if (_selUser.AccessLevel == 2)
                    {
                        Frame frame = new Frame();
                        frame.Navigate(typeof(AdminPage));
                        Window.Current.Content = frame;
                        Window.Current.Activate();
                    }
                    else
                    {
                        Frame frame = new Frame();
                        frame.Navigate(typeof(MainPage));
                        Window.Current.Content = frame;
                        Window.Current.Activate();
                    }
                }

                else
                {
                    _loginPageViewModel.Message = "Wrong password";
                }
            }
            catch (Exception)
            {
                _loginPageViewModel.Message = "Select a user";
            }


        }

        public void RemoveEmployeeWithoutUser()
        {
            UpdateObsCollection updater = new UpdateObsCollection();
            updater.GetEmployeesAsync(_loginPageViewModel.EmployeeCollection);
            foreach (Employees employee in _loginPageViewModel.EmployeeCollection)
            {
                if (employee.UserID == null)
                {
                    _loginPageViewModel.EmployeeCollection.Remove(employee);
                }
            }
        }

        #endregion
    }
}
