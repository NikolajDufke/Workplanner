using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WorkPlanner.Catalog;
using WorkPlanner.Interface;
using WorkPlanner.Model;
using WorkPlanner.Proxy;
using WorkPlanner.View;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    class MainPageHandler :ViewBaseHandler
    {
        private MainPageViewModel _viewmodel;
        private WorktimeProxy proxy;

        Catalog<Employees> EmployeeCatalog = CatalogsSingleton.Instance.EmployeeCatalog;


        public MainPageHandler(MainPageViewModel viewmodel): base(viewmodel)
        {
            proxy = new WorktimeProxy();
            _viewmodel = viewmodel;
            _viewmodel.Date = DateTime.Now;
            LoadWorktimes();
        }

        public async void LoadWorktimes()
        {

            await proxy.Reload();
            List<Worktimes> worktimes = proxy.GetAllWorktimesOfDay(_viewmodel.Date);

            if (worktimes.Count == 0)
            {
                
                worktimes = proxy.GetAllWorktimesOfDay(_viewmodel.Date);
            }

            _viewmodel.Worktimes.Clear();
            foreach (var worktime in worktimes)
            {
                try
                {
                    Employees emp = await EmployeeCatalog.GetSingleAsync(worktime.EmployeeID.ToString());
             
                WorktimeEventDetails WTevent =  new WorktimeEventDetails(emp, worktime);
                WTevent.AttachSubscriber(_viewmodel);
                _viewmodel.Worktimes.Add(new WorktimeEventDetails(emp, worktime));
                }
                catch (Exception e)
                {
                   _viewModelBase.ErrorList.Add(e.Message);
                }
            }

        }

        public void HamburgerButton_Checked()
        {
            _viewmodel.IsPaneOpen = !_viewmodel.IsPaneOpen;
        }

        //TODO inplement update on single event.
        public async void UpdateEventElement()
        {

        }

        public void CheckinChectOut(int ev)
        {
            Worktimes SelectedWorktime =  proxy.GetWorktimeById(ev);

            if (SelectedWorktime.CheckIn == null)
            {
                SelectedWorktime.CheckIn = DateTime.Now;
                CatalogsSingleton.Instance.WorktimeCatalog.UpdateAsync(SelectedWorktime, SelectedWorktime.WorkTimeID.ToString());
                LoadWorktimes();
            }
            else if (SelectedWorktime.CheckOut == null)
            {
                SelectedWorktime.CheckOut = DateTime.Now;
                CatalogsSingleton.Instance.WorktimeCatalog.UpdateAsync(SelectedWorktime, SelectedWorktime.WorkTimeID.ToString());
                LoadWorktimes();
            }
        }

        public void NavigateToUser()
        {
            Frame frame = new Frame();
            frame.Navigate(typeof(LoginPage));
            Window.Current.Content = frame;
            Window.Current.Activate();
        }

        public void NagigateToAdmin()
        {
            Frame frame = new Frame();
            frame.Navigate(typeof(LoginPage));
            Window.Current.Content = frame;
            Window.Current.Activate();
        }
    }
}
