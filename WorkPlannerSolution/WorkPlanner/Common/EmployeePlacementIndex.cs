using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    /// <summary>
    /// Denne klasse har et index af employees og vil tildele en unik farve når man tilføjer nye employees.
    /// </summary>
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

        /// <summary>
        /// adds a employee to the color index
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employees employee)
        {
            //Only adds if the employee is not in the list.
            if (!_Employees.ContainsKey(employee.EmployeeID))
            {
                //adds the emplyee to the employee distionary.
                _Employees.Add(employee.EmployeeID, employee);
                //gives the employee a color that is not in use.
                _colorIndex.Add(employee.EmployeeID, _colersState.FirstOrDefault(x => x.Value == false).Key);
                //sets the color that is given as in use (true).
                _colersState[_colorIndex[employee.EmployeeID]] = true;
            }
        }

        /// <summary>
        /// Get the color that has been assigned to the specific employee. else returns and empty string.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public string GetEmployeeColor(int employeeId)
        {

            if (_Employees.ContainsKey(employeeId))
                return _colorIndex[employeeId];

            return "";
        }

        /// <summary>
        /// Returns a list of Employees that has been added to the index.
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployees()
        {
            return _Employees.Values.ToList();
        }

        /// <summary>
        /// Clears all the entries and resets the index.
        /// </summary>
        public void Clear()
        {
            _Employees.Clear();
            _colorIndex.Clear();
            //This will make a new dictionary with all values as false.
            _colersState = _colersState.ToDictionary(x => x.Key, x => false);
        }

        /// <summary>
        /// Retruns true if the employee exist in the index.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool ContainsImployee(int employeeId)
        {
            return _Employees.ContainsKey(employeeId);
        }

        public List<WorktimeEventDetails> GetWorktimeEventDetails()
        {
            List<WorktimeEventDetails> listWed = new List<WorktimeEventDetails>();

            foreach (var i in _colorIndex)
            {
                listWed.Add(new WorktimeEventDetails(i.Value,_Employees[i.Key].FirstName + " " + _Employees[i.Key].LastName, 0));
            }

            return listWed;

            return null;
        }
    }




}

