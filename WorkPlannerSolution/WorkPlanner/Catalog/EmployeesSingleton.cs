using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using WorkPlanner.Model;

namespace WorkPlanner.Catalog
{
    public class EmployeesSingleton
    {
        private static EmployeesSingleton _instance;

        public EmployeesSingleton()
        {
        }

        public static EmployeesSingleton Instance
        {
            get { return _instance ?? (_instance = new EmployeesSingleton()); }
        }

        private Employees _employeesObject;

        public Employees EmployeesObject
        {
            get
            {
                if (_employeesObject == null)
                {
                    _employeesObject = new Employees();
                }
                return _employeesObject;
            }
            set { _employeesObject = value; }
        }
    }
}
