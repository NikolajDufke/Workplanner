using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;

namespace WorkPlanner.Interface
{
    public interface IWorkTimeEventDetailObserver
    {
        void Update(Worktimes worktime);
    }
}
