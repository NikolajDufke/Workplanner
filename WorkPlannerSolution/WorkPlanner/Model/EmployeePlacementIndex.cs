using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    class EmployeePlacementIndex
    {
        private Dictionary<int, string> _colorIndex;
        private Dictionary<int, Employees> _Employees;
        private Dictionary<string, bool> _colersState;

        public EmployeePlacementIndex()
        {
            _Employees = new Dictionary<int, Employees>();
            _colorIndex = new Dictionary<int, string>();
            _colersState = new Dictionary<string, bool>();

            Clear();
          
        }

        public void AddEmployee(Employees employee)
        {
            if (!_Employees.ContainsKey(employee.EmployeeID))
            {
                _Employees.Add(employee.EmployeeID, employee);
                _colorIndex.Add(employee.EmployeeID, _colersState.FirstOrDefault(x => x.Value == false).Key);
                _colersState[_colorIndex[employee.EmployeeID]] = true;
            }
        }

        public string GetEmployeeColor(int employeeId)
        {
            if (_Employees.ContainsKey(employeeId))
                return _colorIndex[employeeId];

            return "";
        }

        public List<Employees> GetEmployees()
        {
            return _Employees.Values.ToList();
        }

        public void Clear()
        {
            _Employees.Clear();
            _colorIndex.Clear();
            #region Color Selection
            _colersState.Clear();
            _colersState.Add("DarkMagenta", false);
            _colersState.Add("DarkOrange", false);
            _colersState.Add("DarkGreen", false);
            _colersState.Add("Aqua", false);
            _colersState.Add("Indigo", false);
            _colersState.Add("Plum", false);
            _colersState.Add("MediumPurple", false);

            #endregion
        }

        public bool ContainsImployee(int employeeId)
        {
            return _Employees.ContainsKey(employeeId);
        }
    }




}

