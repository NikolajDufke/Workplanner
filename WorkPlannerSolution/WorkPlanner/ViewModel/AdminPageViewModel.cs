using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    class AdminPageViewModel : ViewModelBase
    {
        AllViewItems rows;
        private ObservableCollection<Time> _time;
        private ObservableCollection<Columns> _column;

        public AdminPageViewModel()
        {
            List<int> i = new List<>(){};

            _række1.Add(new EventElement();


            rows = new AllViewItems();

            rows.Addmember(new TimeSpan(8, 30, 0), new Employees() { EInformationID = 1, EmployeeId = 1, UserID = 1 }, 1);
            rows.Addmember(new TimeSpan(9, 30, 0), new Employees() { EInformationID = 2, EmployeeId = 2, UserID = 2 }, 2);
            rows.Addmember(new TimeSpan(10, 30, 0), new Employees() { EInformationID = 2, EmployeeId = 2, UserID = 2 }, 3);
            rows.Addmember(new TimeSpan(11, 30, 0), new Employees() { EInformationID = 3, EmployeeId = 3, UserID = 3 }, 4);
            rows.Addmember(new TimeSpan(12, 30, 0), new Employees() { EInformationID = 4, EmployeeId = 4, UserID = 4 }, 5);
            rows.Addmember(new TimeSpan(13, 30, 0), new Employees() { EInformationID = 5, EmployeeId = 5, UserID = 5 }, 6);

            _allView.Add(rows);
            _allView.Add(rows);


            _time = new ObservableCollection<Time>();
            _time.Add(new Time(){TimeID = 1, GetTime = new TimeSpan(8, 30, 0)});
            _time.Add(new Time() { TimeID = 2, GetTime = new TimeSpan(9, 30, 0) });
            _time.Add(new Time() { TimeID = 3, GetTime = new TimeSpan(10, 30, 0) });
            _time.Add(new Time() { TimeID = 4, GetTime = new TimeSpan(11, 30, 0) });

            _column = new ObservableCollection<Columns>();

            var e1 = new Employees(){ EInformationID = 1,EmployeeId = 1, UserID = 1};
            var e2 = new Employees() { EInformationID = 2, EmployeeId = 2, UserID = 2 };
            var e3 = new Employees() { EInformationID = 3, EmployeeId = 3, UserID = 3 };


            var w1 = new Worktimes(1,  1, DateTime.Now, DateTime.Now);
            var w2 = new Worktimes(2, 2, DateTime.Now, DateTime.Now);
            var w3 = new Worktimes(3, 3, DateTime.Now, DateTime.Now);
            var w4 = new Worktimes(4, 1, DateTime.Now, DateTime.Now);

            List<Worktimes> wt = new List<Worktimes>(){w1,w2,w3,w4}; 
            


            var r = new Row()
            {
                TimeID = 1,
                Deltagere = new List<Employees>() { e1, e2, e3},
                
            };
            var r2 = new Row()
            {
                TimeID = 1,
                Deltagere = new List<Employees>() { e1, e2, e3 },

            };

            


            _column.Add(new Columns()
            {
                Date = DateTime.Now,
                Rows = new List<Row>(){r,r2},
                WorkTime = wt
                
            });
            _column.Add(new Columns()
            {
                Date = DateTime.Now,
                Rows = new List<Row>(){r,r2},
                WorkTime = wt

            });


        }


        private ObservableCollection<AllViewItems> _allView;

        public ObservableCollection<AllViewItems> AllView
        {
            get { return _allView; }
            set { _allView = value; }
        }


        public ObservableCollection<Time> Time
        {
            get { return _time; }
            set { _time = value; }
        }

    
  
      
        
        public ObservableCollection<Columns> Column
        {
            get { return _column; }
            set { _column = value; }
        }


        private ObservableCollection<Row> _events1;

        public ObservableCollection<Row> Events1
        {
            get { return _events1; }
            set { _events1 = value; }
        }

        private ObservableCollection<Row> _events2;

        public ObservableCollection<Row> Events2
        {
            get { return _events2; }
            set { _events2 = value; }
        }



        private ObservableCollection<EventElement> _række1;

        public ObservableCollection<EventElement> Række1
        {
            get { return _række1; }
            set { _række1 = value; }
        }

        private ObservableCollection<EventElement> _række2;

        public ObservableCollection<EventElement> Række2
        {
            get { return _række2; }
            set { _række2 = value; }
        }

        private ObservableCollection<EventElement> _række3;
        
        public ObservableCollection<EventElement> Række3
        {
            get { return _række3; }
            set { _række3 = value; }
        }














        //private ObservableCollection<RowViewItems> _weekviewCollection;

        //public ObservableCollection<RowViewItems> WeekViewItems
        //{
        //    get { return _weekviewCollection; }
        //    set { _weekviewCollection = value; }
        //}

        //public ObservableCollection<string> Headers
        //{
        //    get { return new ObservableCollection<string>(rows.Headers);}
        //    //set { rows.Headers = value; }
        //}

        //private ObservableCollection<TimeIntervalDetails> _timeInterval;

        //public ObservableCollection<TimeIntervalDetails> TimeInterval
        //{
        //    get { return _timeInterval; }
        //    set { _timeInterval = value; }
        //}


        //public AllViewItems AllItems
        //{
        //    get { return rows; }
        //    set { rows = value; }
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
