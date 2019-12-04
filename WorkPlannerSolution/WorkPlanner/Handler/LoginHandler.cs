using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Catalog;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    class LoginHandler
    {
        private LoginPageViewModel _loginPageViewModel;
        private List<Users> _userList;

        public LoginHandler(LoginPageViewModel loginpageevm)
        {
            _loginPageViewModel = loginpageevm;
            this._loginPageViewModel = loginpageevm;
            // Users indeholder passwords. måske skal vi ikke hante alle passwords ned på en gang ? 
            // Vi kan få fat i en hvis vi har id på brugeren.
            //_userList = CatalogsSingleton.Instance.UsersCatalog.GetAll;
        }

        public void LoginUser()
        {
            foreach (Users user in _userList)
            {
                
            }
        }
    }
}
