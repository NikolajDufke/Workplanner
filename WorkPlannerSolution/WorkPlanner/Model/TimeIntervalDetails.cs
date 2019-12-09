using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    class TimeIntervalDetails
    {
        Dictionary<int,Employees> _eventMembers;

        public TimeIntervalDetails()
        {
            _eventMembers = new Dictionary<int, Employees>();
        }

        public List<Employees> GetMembers
        {
            get{ return _eventMembers.Values.ToList();}
        }

        public void AddMember(Employees employee)
        {
            if(!_eventMembers.ContainsKey(employee.EmployeeID))
            _eventMembers.Add(employee.EmployeeID,employee);          
        }

        public void RemoveMember(int employeeID)
        {
            if (_eventMembers.ContainsKey(employeeID))
                _eventMembers.Remove(employeeID);
        }

        public void UpdateMember(Employees employee)
        {
            if (_eventMembers.ContainsKey(employee.EmployeeID))
                _eventMembers[employee.EmployeeID]=employee;
        }

        public bool Update
        {
            get
            {
              return _eventMembers.Count > 0 ?  true :  false;
            }
        }
      
    }
}
