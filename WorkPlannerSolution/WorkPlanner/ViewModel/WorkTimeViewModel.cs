﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkPlanner.Catalog;
using WorkPlanner.Common;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class WorkTimeViewModel : ViewModelBase
    {
        #region Instance
        private int _id;
        private string _name;
        private Employees _employeeProp;
        private DateTimeOffset _dateTime;
        private TimeSpan _time1;
        private TimeSpan _time2;
        private WorkTimeHandler _workTimeHandler;
        private static Worktimes _selectedworktime;
        private ICommand _selectedWorktimeCommand;
        private string _message;
        private ObservableCollection<Employees> _employee;
        #endregion

        #region Constructer
        public WorkTimeViewModel()
        {
            _employee = new ObservableCollection<Employees>();
            _workTimeHandler = new WorkTimeHandler(this);

            GetEmployeesAsync();

            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, new TimeSpan());
            TimeStart = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            TimeEnd = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            WorkTimeCreateCommand = new RelayCommand(_workTimeHandler.CreateWorkTime);
        }
        #endregion

        #region Properties
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public Employees EmployeeProp
        {
            set { _employeeProp = value;}
            get { return _employeeProp; }
        }

        public DateTimeOffset Date
        {
            set
            {
                _dateTime = value; 
                OnPropertyChanged();
            }
            get
            {
                return _dateTime; 

            }
        }

        public TimeSpan TimeStart
        {
            set { _time1 = value; }
            get { return _time1; }
        }

        public TimeSpan TimeEnd
        {
            set { _time2 = value; }
            get { return _time2; }
        }

        public WorkTimeHandler Worktimeh
        {
            set { _workTimeHandler = value; }
            get { return _workTimeHandler; }
        }
        #endregion

        #region ObservableCollection

        //En observablecollection så man kan få fat i firstname der ligger inde i Employee

        public ObservableCollection<Employees> Employee
        {
            get { return _employee; }
        }
        #endregion

        #region ICommands
        public ICommand WorkTimeCreateCommand { set; get; }
        #endregion

        #region Methods
        /// <summary>
        /// Gør så man kan hente Employees asynkront mens programmet kører.
        /// </summary>
        public async void GetEmployeesAsync()
        {
           List<Employees> listE = await CatalogsSingleton.Instance.EmployeeCatalog.GetAll();
           foreach (Employees e in listE)
           {
               _employee.Add(e);
           }
        }
        #endregion

    }
}