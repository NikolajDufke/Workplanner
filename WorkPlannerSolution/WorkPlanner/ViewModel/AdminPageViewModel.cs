using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    class AdminPageViewModel : ViewModelBase
    {

        public AdminPageViewModel()
        {
            _weekviewCollection = new ObservableCollection<WeekViewItems>();
          
         pupulate();

        }
  

        private ObservableCollection<WeekViewItems> _weekviewCollection;

        public ObservableCollection<WeekViewItems> WeekViewItems
        {
            get { return _weekviewCollection; }
            set { _weekviewCollection = value; }
        }

        private ObservableCollection<string> myVar;

        public ObservableCollection<string> MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }






        private void pupulate()
        {
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "08:00 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"
                
            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "08:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:00 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });
            WeekViewItems.Add(new WeekViewItems()
            {
                Time = "09:30 -",
                Mandag = "test1",
                Tirsdag = "test2",
                Onsdag = "test3",
                Torsdag = "test4",
                Fredag = "test5",
                Lørdag = "test6",
                Søndag = "test7"

            });

        }

    }
}
