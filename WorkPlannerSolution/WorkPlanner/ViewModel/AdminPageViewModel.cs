using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Catalog;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class AdminPageViewModel : ViewModelBase
    {
        #region Instance

        private Employees _employeeInformationProp;
        private AdminHandler _adminHandler;
        private string _name;
        #endregion

        #region Constructor

        public AdminPageViewModel()
        {
            var T = CatalogsSingleton.Instance.EmployeeCatalog.GetAll;
            _adminHandler = new AdminHandler(this);
        }

        #endregion

        #region properties

        public Employees employeeInformationProp
        {
            get { return _employeeInformationProp; }
            set { _employeeInformationProp = value; }
        }

        public AdminHandler AdminH
        {
            get { return _adminHandler; }
            set { _adminHandler = value; }
        }
        #endregion

        #region ObservabelCollection

        public ObservableCollection<Employees> EmployeeInformations
        {
            get { return CatalogsSingleton.Instance.EmployeeCatalog.GetAll; }
        }

#endregion
        //public AdminPageViewModel()
        //{
        //    _weekviewCollection = new ObservableCollection<RowViewItems>();

        //    //pupulate();

        //}


        //private ObservableCollection<WeekViewItems> _weekviewCollection;

        //public ObservableCollection<WeekViewItems> WeekViewItems
        //{
        //    get { return _weekviewCollection; }
        //    set { _weekviewCollection = value; }
        //}

        //private ObservableCollection<string> myVar;

        //public ObservableCollection<string> MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}






        //private void pupulate()
        //{
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "08:00 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "08:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:00 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });
        //    WeekViewItems.Add(new WeekViewItems()
        //    {
        //        Time = "09:30 -",
        //        Mandag = "test1",
        //        Tirsdag = "test2",
        //        Onsdag = "test3",
        //        Torsdag = "test4",
        //        Fredag = "test5",
        //        Lørdag = "test6",
        //        Søndag = "test7"

        //    });

        //}

    }
}
