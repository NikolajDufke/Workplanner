using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Interface;

namespace WorkPlanner.Model
{
    public class WorktimeEventDetails : IWorktimeEventDetailSubject, IDisposable
    {
        private string _color;
        private Employees _employee;
        private Worktimes _worktime;
        private IList<IWorkTimeEventDetailObserver> observers = new List<IWorkTimeEventDetailObserver>();
       private bool _statusManagerStatus;
        public WorktimeEventDetails(Employees employee, Worktimes worktime)
        {
            _statusManagerStatus = true;

           
            _employee = employee;
            _worktime = worktime;
            StatusManager(5000);
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Name
        {
            get { return _employee.FirstName + " " + _employee.LastName; ; }
        }

        public int WorktimeID
        {
            get { return _worktime.WorkTimeID; }
        }

        public DateTime StarTime
        {
            get { return _worktime.TimeStart; }
        }

        public DateTime EndTime
        {
            get { return _worktime.TimeEnd; }
        }

        public bool CheckedIn
        {
            get
            {

                return _worktime.CheckIn != null && _worktime.CheckOut == null;

            }
        }

        private string _statusColor;

        public string StatusColor
        {
            get
            {
                if (CheckedIn)
                {
                    if (_worktime.TimeEnd < DateTime.Now || _worktime.TimeStart > DateTime.Now)
                    {
                        return "Blue";
                    }
                    return "Green";
                }
                else if (_worktime.CheckOut != null)
                {
                    if (_worktime.TimeEnd > _worktime.CheckOut)
                    {
                        return "Red";
                    }
                    return "Yellow";
                }
                else if (_worktime.CheckIn == null)
                {
                    return "";
                }

                return "Grey";

            }
        }

        public void AttachSubscriber(IWorkTimeEventDetailObserver subscriber)
        {
            observers.Add(subscriber);
        }

        public void DetachSubscriber(IWorkTimeEventDetailObserver subscriber)
        {
            if (!observers.Contains(subscriber))
                throw new ArgumentException("Subscriber does not exist");
            observers.Remove(subscriber);

        }

        public void notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(_worktime);
            }
        }


        public async void StatusManager(int delay)
        {
            while (_statusManagerStatus)
            {
                //Hvis der er checked in
                if (_worktime.CheckIn != null)
                {
                    if (_worktime.CheckOut == null)
                    {
                        if (_worktime.TimeEnd > DateTime.Now)
                        {
                            await Task.Delay(delay);
                        }

                        else if (_worktime.TimeEnd <= DateTime.Now)
                        {
                            notify();
                            _statusManagerStatus = false;
                        }

                    }
                    else if (_worktime.CheckOut != null)
                    {
                        _statusManagerStatus = false;
                    }

                }
                else if (_worktime.CheckIn == null && _worktime.CheckOut == null)
                {
                    await Task.Delay(delay * 2);
                }
                else
                {
                    _statusManagerStatus = false;
                }

            }
        }

        public void Dispose()
        {
            _statusManagerStatus = false;
        }
    }



}
