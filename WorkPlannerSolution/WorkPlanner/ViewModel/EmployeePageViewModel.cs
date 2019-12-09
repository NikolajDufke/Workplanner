using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Catalog;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class EmployeePageViewModel
    {
        private Employees _employeeProp;

        public EmployeePageViewModel()
        {
            //Employees = new ObservableCollection<Employees>();

        }

        public Employees EmployeeProp
        {
            set { _employeeProp = value; }
            get { return _employeeProp; }
        }
    }
}