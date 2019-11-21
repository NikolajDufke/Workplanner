using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    class Users
    {
        private string _userPassword;
        private int _accessLevel;

        public int AccessLevel
        {
            get { return _accessLevel; }
            set { _accessLevel = value; }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

    }
}
