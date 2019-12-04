using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    class LoginPageViewModel : ViewModelBase
    {
        private ObservableCollection<Employees> _employeeCatalog;
        private Employees _selEmployees;
        private string _password;
        private Handler.LoginHandler _loginHander;
        private ICommand _loginCommand;
        private string _message;

        public LoginPageViewModel()
        {
            _employeeCatalog = new ObservableCollection<Employees>();
            
            GetEmployeesAsync();
            
            _loginHander = new LoginHandler(this);
         
        }

        public ObservableCollection<Employees> EmployeeCollection
        {
            get
            {
                return _employeeCatalog;
            }
        }

        public Employees SelEmployees
        {
            get { return _selEmployees; }
            set { _selEmployees = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateEmployeeCommand
        {
            get
            {
                return _loginCommand ??
                       (_loginCommand = new RelayCommand(_loginHander.LoginUser));
            }
            set { _loginCommand = value; }
        }

        public async void GetEmployeesAsync()
        {
            List<Employees> listE = await CatalogsSingleton.Instance.EmployeeCatalog.GetAll();
            foreach (Employees e in listE)
            {
                _employeeCatalog.Add(e);
            }
        }
    }
}
