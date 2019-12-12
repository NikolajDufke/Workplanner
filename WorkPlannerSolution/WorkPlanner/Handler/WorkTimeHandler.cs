using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Catalog;
using WorkPlanner.Converter;
using WorkPlanner.ViewModel;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class WorkTimeHandler
    {
        #region Instance
        private WorkTimeViewModel _workTimeViewModel;
        private CatalogsSingleton _catalogs;
        #endregion

        #region Constructer
        public WorkTimeHandler(WorkTimeViewModel workTimevm)
        {
            _workTimeViewModel = workTimevm;
            this._workTimeViewModel = workTimevm;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Metode der gør så man kan oprette en worktime, som indeholder en Timestart, TimeEnd, Date og EmployeeId.
        /// Denne metode bruges også til at sende beskeder ud i view hvis en worktime er oprettet eller ikke oprettet.
        /// </summary>
        public async void CreateWorkTime()
        {
            var sts = _workTimeViewModel.TimeStart;
            var ste = _workTimeViewModel.TimeEnd;
            var tsv = _workTimeViewModel.Date;
            var empid = _workTimeViewModel.EmployeeProp.EmployeeID;

            Worktimes worktimes = new Worktimes()
            {
                TimeStart = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(tsv, sts),
                TimeEnd = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(tsv, ste),
                Date = DateTimeConverter.DateTimeOffsetToDateTime(tsv),
                EmployeeID = empid
            };

            var catalog = Catalog.CatalogsSingleton.Instance;

            if (_workTimeViewModel.EmployeeProp.FirstName != null)
            {
                await catalog.WorktimeCatalog.AddAsync(worktimes);

                _workTimeViewModel.Message = "WorkTime er oprettet";
            }
            else
            {
                _workTimeViewModel.Message = "WorkTime kunne ikke oprettes";
            }

        }
        #endregion
    }
}