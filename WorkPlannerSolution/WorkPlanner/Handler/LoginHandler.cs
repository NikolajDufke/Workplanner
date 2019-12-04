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

namespace WorkPlanner.Handler
{
    class LoginHandler
    {
        private LoginPageViewModel _loginPageViewModel;
        private Users _selUser;

        public LoginHandler(LoginPageViewModel loginpageevm)
        {
            _loginPageViewModel = loginpageevm;
            this._loginPageViewModel = loginpageevm;

        }

        public async void LoginUser()
        {
            _selUser = await CatalogsSingleton.Instance.UsersCatalog.GetSingleAsync(
                Convert.ToString(_loginPageViewModel.SelEmployees.UserID));
            if (_selUser.UserPassword == _loginPageViewModel.Password)
            {
                if (_selUser.AccessLevel == 0)
                {
                    Frame frame = new Frame();
                    frame.Navigate(typeof(AdminPage));
                    Window.Current.Content = frame;
                    Window.Current.Activate();
                }
                else if (_selUser.AccessLevel == 1)
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
                else if (_selUser.AccessLevel == 3)
                {

                }
            }

            else
            {
                _loginPageViewModel.Message = "Wrong password";
            }
        }
    }
}
