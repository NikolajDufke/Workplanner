using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    public class OverTimeRequest 
    {
        private Employees _requester;
        private Worktimes _worktime;
        public Employees Requester
        {
            get { return _requester; }
            set { _requester = value; }
        }

        public Worktimes Worktime
        {
            get { return _worktime; }
            set { _worktime = value; }
        }

        public void AcceptRequest()
        {

        }

        public void RejectRequest()
        {

        }




    }
}
