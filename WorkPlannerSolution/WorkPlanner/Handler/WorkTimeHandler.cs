using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.ViewModel;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class WorkTimeHandler
    {
        private WorkTimeViewModel _workTimeViewModel;
        private List<Worktime> allWorktimes;
        

        public WorkTimeHandler(WorkTimeViewModel workTimevm)
        {
            _workTimeViewModel = workTimevm;
            this._workTimeViewModel = workTimevm;
        }

        public void SetSelectedWorkTime(object id)
        {
            int Id = Convert.ToInt16(id);

            foreach (Worktime wt in allWorktimes)
            {
                if (wt.WorkTimeId == Id)
                {
                    WorkTimeViewModel.SelectedWorktime = wt;
                }
            }
        }
    }
}