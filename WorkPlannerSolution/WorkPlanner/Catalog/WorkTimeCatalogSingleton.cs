using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Persistency;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Model
{
    public class WorkTimeCatalogSingleton
    {
        private static WorkTimeCatalogSingleton _instance;
        private ObservableCollection<Worktime> _worktimes;
        private const string _serverurl = "http://localhost:56265/";
        private const string _serverprefix = "worktime";
        private WebApiWorkPlanner<Worktime> _worktimePersistency;
        #region Singleton
        public static WorkTimeCatalogSingleton Instance
             {
                 get
                 {
                    if (_instance == null)
                    {
                        _instance = new WorkTimeCatalogSingleton();
                        return _instance;
                    }
                    return _instance;
                 }
             }
        #endregion

        public WorkTimeCatalogSingleton()
        {
            _worktimes = new ObservableCollection<Worktime>();

            _worktimePersistency = new WebApiWorkPlanner<Worktime>(_serverurl, _serverprefix);
        }

        public ObservableCollection<Worktime> Worktimes
        {
            get { return _worktimes; }
        }

        public async Task AddWorktime(int WorkTimeId, int EmployeeId, DateTime Date, DateTime Time)
        {
            if (WorkTimeId == null && EmployeeId == null)
            {
                Worktime newWorktime = new Worktime(WorkTimeId, EmployeeId, Date, Time);

                _worktimes.Add(newWorktime);
                await _worktimePersistency.Create(newWorktime);
            }
            else
            {
                throw new ArgumentException("Missing WorkTimeID or EmployeeId");
            }
        }

        public async Task RemoveWorktime(Worktime wt)
        {
            if (wt != null)
            {
                _worktimes.Remove(wt);
                await _worktimePersistency.Delete(_serverprefix);
            }
        }
    }
}