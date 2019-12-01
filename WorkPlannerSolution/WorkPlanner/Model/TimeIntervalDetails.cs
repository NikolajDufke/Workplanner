using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public string GetMembers
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var member in _eventMembers)
                {
                    sb.AppendLine(member.Value.EmployeeId.ToString());
                }

                return sb.ToString();
            }
        }

        public void AddMember(Employees employee)
        {
            if(!_eventMembers.ContainsKey(employee.EInformationID))
            _eventMembers.Add(employee.EInformationID,employee);          
        }

        public void RemoveMember(int employeeID)
        {
            if (_eventMembers.ContainsKey(employeeID))
                _eventMembers.Remove(employeeID);
        }

        public void UpdateMember(Employees employee)
        {
            if (_eventMembers.ContainsKey(employee.EInformationID))
                _eventMembers[employee.EInformationID]=employee;
        }

      
    }
}
