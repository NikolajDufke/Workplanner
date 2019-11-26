﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Catalog;
using WorkPlanner.ViewModel;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class WorkTimeHandler
    {
        private WorkTimeViewModel _workTimeViewModel;
        private List<Worktimes> allWorktimes;
        private CatalogsSingleton _catalogs;
        private Worktimes worktime;
        

        public WorkTimeHandler(WorkTimeViewModel workTimevm)
        {
            _workTimeViewModel = workTimevm;
            this._workTimeViewModel = workTimevm;
        }

        public void SetSelectedWorkTime(object id)
        {
            int Id = Convert.ToInt16(id);

            foreach (Worktimes wt in allWorktimes)
            {
                if (wt.WorkTimeId == Id)
                {
                    WorkTimeViewModel.SelectedWorktime = wt;
                }
            }
        }

        public async void CreateWorkTime()
        {
                await _catalogs.WorktimeCatalog.AddAsync(worktime);
        }
    }
}