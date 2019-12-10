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
      private  Dictionary<int,Employees> _eventMembers;
       private Dictionary<int, WorktimeEventDetails> _worktimeEventDetails;
        public TimeIntervalDetails()
        {
            _eventMembers = new Dictionary<int, Employees>();
            _worktimeEventDetails = new Dictionary<int, WorktimeEventDetails>();
        }

        public List<Employees> GetMembers
        {
            get{ return _eventMembers.Values.ToList();}
        }
        public WorktimeEventDetails GetWorktimeEventDetail(int employeeID)
        {
             return _worktimeEventDetails[employeeID]; 
        }

        public void AddMember(Employees employee, WorktimeEventDetails worktimeDetails)
        {
            if (!_eventMembers.ContainsKey(employee.EmployeeID))
            {
                _eventMembers.Add(employee.EmployeeID, employee);
                _worktimeEventDetails.Add(employee.EmployeeID,worktimeDetails);
            }
        }

        //public void RemoveMember(int employeeID)
        //{
        //    if (_eventMembers.ContainsKey(employeeID))
        //    {
        //        _eventMembers.Remove(employeeID);
        //        _worktimeEventDetails.Remove(employeeID);
        //    }

        //}

        //public void UpdateMember(Employees employee)
        //{
        //    if (_eventMembers.ContainsKey(employee.EmployeeID))
        //        _eventMembers[employee.EmployeeID]=employee;
        //}

        public bool Update
        {
            get
            {
              return _eventMembers.Count > 0 ?  true :  false;
            }
        }

    


    }
}
