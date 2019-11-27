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

        public ObservableCollection<Employees> GetMembers
        {
            get
            {
                return new ObservableCollection<Employees>(_eventMembers.Values);
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
