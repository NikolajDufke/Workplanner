using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.NetworkOperators;
using WorkPlanner.Catalog;
using WorkPlanner.Model;
using WorkPlanner.Proxy;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    class MainPageHandler
    {

        MainPageViewModel _viewmodel;
        private WorktimeProxy proxy;

        Catalog<Employees> EmployeeCatalog = CatalogsSingleton.Instance.EmployeeCatalog;


        public MainPageHandler(MainPageViewModel viewmodel)
        {
            proxy = new WorktimeProxy();
            _viewmodel = viewmodel;
            _viewmodel.Date = DateTime.Now;
            LoadWorktimes();
        }

        public async void LoadWorktimes()
        {
            List<Worktimes> worktimes = proxy.GetAllWorktimesOfDay(_viewmodel.Date);

            if (worktimes.Count == 0)
            {
                await proxy.Reload();
                worktimes = proxy.GetAllWorktimesOfDay(_viewmodel.Date);
            }

            _viewmodel.Worktimes.Clear();
            foreach (var worktime in worktimes)
            {

                Employees emp = await EmployeeCatalog.GetSingleAsync(worktime.EmployeeID.ToString());


                new WorktimeEventDetails(emp, worktime);

                _viewmodel.Worktimes.Add(new WorktimeEventDetails(emp, worktime));
            }

        }

        public void CheckinChectOut(int ev)
        {
            throw new NotImplementedException();
        }
    }
}
