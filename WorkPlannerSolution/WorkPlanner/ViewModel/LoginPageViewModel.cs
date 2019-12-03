using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Catalog;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    class LoginPageViewModel
    {
        private ObservableCollection<Employees> _employeeCatalog;

        public LoginPageViewModel()
        {
            _employeeCatalog = CatalogsSingleton.Instance.EmployeeCatalog.GetAll;
        }

        public ObservableCollection<Employees> EmployeeCollection
        {
            get
            {
                return _employeeCatalog;
            }
        }
    }
}
