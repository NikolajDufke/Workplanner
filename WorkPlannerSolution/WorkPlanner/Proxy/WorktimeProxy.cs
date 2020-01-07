using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Globalization.DateTimeFormatting;
using WorkPlanner.Catalog;
using WorkPlanner.Model;

namespace WorkPlanner.Proxy
{
   public class WorktimeProxy
    {
        private bool IsFecthingData = false;
        private List<Worktimes> _allWorktimes;
        private Catalog<Worktimes> Catalog;

        private bool Updateing_casheSortedById;

        //private TwoKeyDictionary<int, int, List<Worktimes>> _casheSortedByWeek;
        private Dictionary<int, Worktimes> _casheSortedById;
        private Dictionary<int, Dictionary<DateTime, List<Worktimes>>> _casheSortedByDay;
        private Dictionary<int, List<Worktimes>> _casheSortedByEmployee;

        //private TreeKeyDictionary<int,int,int,List<Worktimes>> _cashed_Employee_Week;
        public WorktimeProxy()
        {
            _allWorktimes = new List<Worktimes>();
            //_cashed_Employee_Week =new TreeKeyDictionary<int, int, int, List<Worktimes>>();
            _casheSortedByDay = new Dictionary<int, Dictionary<DateTime, List<Worktimes>>>();
            _casheSortedByEmployee = new Dictionary<int, List<Worktimes>>();
            _casheSortedById = new Dictionary<int, Worktimes>();
            Catalog = CatalogsSingleton.Instance.WorktimeCatalog;

            LoadAll();
        }

        //Udkommenteret kode for GetWorktimesOfEmployeeInWeek og  GetAllWorktimesOfWeek
        //En eller anden form for access validation.
        //public List<Worktimes> GetWorktimesOfEmployeeInWeek(int id, int weekNumber, int year = 0)
        //{

        //    year = (year == 0) ? DateTime.Now.Year : year;


        //    List<Worktimes> result = null;

        //    if (_cashed_Employee_Week.ContainsKey(year))
        //    {
        //        if (_cashed_Employee_Week[year].ContainsKey(weekNumber))
        //        {
        //            if (_cashed_Employee_Week[year][weekNumber].ContainsKey(id))
        //            {
        //                result = _cashed_Employee_Week[year][weekNumber][id];
        //            }
        //        }
        //    }

        //    else
        //    {
        //       result =  _allWorktimes.FindAll(x => x.EmployeeID == id && x.Date.DayOfYear / 7 == weekNumber);
        //       if (result.Count != 0 && result != null)
        //       {
        //           _cashed_Employee_Week[year][id][weekNumber] = result;
        //       }
        //    }
        //    return result;
        ////}

        //public List<Worktimes> GetAllWorktimesOfWeek(int weekNumber ,int year = 0)
        //{
        //    year = (year == 0) ? DateTime.Now.Year : year;

        //    List<Worktimes> result = null;

        //    if (!_casheSortedByWeek.ContainsKey(year))
        //    {
        //        if(!_casheSortedByWeek[year].ContainsKey(weekNumber))
        //        result = _allWorktimes.FindAll(x => x.Date.DayOfYear / 7 == weekNumber);
        //        _casheSortedByWeek[year][weekNumber] = result;
        //        return result;
        //    }

        //    return _casheSortedByWeek[year][weekNumber];

        //}

        public Worktimes GetWorktimeById(int WorktimeId)
        {
            if (_casheSortedById.ContainsKey(WorktimeId))
            {
                return _casheSortedById[WorktimeId];
            }

            if (Updateing_casheSortedById)
            {
                //TODO implement endlessloop prevention
                while (Updateing_casheSortedById)
                {
                    if (Updateing_casheSortedById == true)
                    {
                        if (_casheSortedById.ContainsKey(WorktimeId))
                        {
                            return _casheSortedById[WorktimeId];
                        }
                    }

                }
            }

            Updateing_casheSortedById = true;

            foreach (var worktime in _allWorktimes)
            {
                if (worktime.WorkTimeID == WorktimeId)
                {
                    _casheSortedById.Add(worktime.WorkTimeID, worktime);
                    Updateing_casheSortedById = false;
                    return worktime;
                }

                if(!_casheSortedById.ContainsKey(worktime.WorkTimeID))
                    _casheSortedById.Add(worktime.WorkTimeID, worktime);
            }

            return null;

        }

        public void AddWorktimeById(Worktimes worktime)
        {
            _casheSortedById.Add(worktime.WorkTimeID, worktime);
        }


        //TODO Make this an async action. 
        public void AddWorktimesByIdAsync(List<Worktimes> worktimes)
        {

            foreach (var worktime in worktimes)
            {
                if (!_casheSortedById.ContainsKey(worktime.WorkTimeID))
                {
                    AddWorktimeById(worktime);
                }
            }
        }


        public async Task<List<Worktimes>> GetAllWorktimesOfDay(DateTime date, int year = 0)
        {
   
                year = (year == 0) ? DateTime.Now.Year : year;
                date = TrimToDateOnly(date);

                List<Worktimes> result = null;

                if (!_casheSortedByDay.ContainsKey(year))
                {
                    await LoadAll();

                    result = _allWorktimes.FindAll(x => TrimToDateOnly(x.Date) == date);

                    if (result.Count != 0)
                    {
                        _casheSortedByDay[year] = new Dictionary<DateTime, List<Worktimes>>();
                        _casheSortedByDay[year][date] = result;
                    }
                    else
                        return new List<Worktimes>();
                }
                else if (!_casheSortedByDay[year].ContainsKey(date))
                {
                    result = _allWorktimes.FindAll(x => TrimToDateOnly(x.Date) == date);

                    if (result.Count != 0)
                    {
                        AddWorktimesByIdAsync(result);
                        _casheSortedByDay[year][date] = result;
                    }
                    else
                        return new List<Worktimes>();
                }

                return _casheSortedByDay[year][date];

        }

        public List<Worktimes> WorktimeForEmployeeOnSingleDay(DateTime date, Employees employee)
        {
            List<Worktimes> worktimesForEmployee = GetAllWorktimesByEmployee(employee);

            if (worktimesForEmployee.Count > 0)
            { 
                

                return worktimesForEmployee.FindAll(x => x.Date == date);
            }

            return null;
        }

    

    public List<Worktimes> GetAllWorktimesByEmployee(Employees employee)
        {
            if (!_casheSortedByEmployee.ContainsKey(employee.EmployeeID))
            {
                List<Worktimes> result = _allWorktimes.FindAll(x => x.EmployeeID == employee.EmployeeID);
                _casheSortedByEmployee.Add(employee.EmployeeID, result);
            }
            return _casheSortedByEmployee[employee.EmployeeID];
        }

        

        public async Task Reload()
        {
            _allWorktimes.Clear();
            _casheSortedByDay.Clear();
            _casheSortedByEmployee.Clear();
           await LoadAll();
            
        }

        private async Task LoadAll()
        {
        
            _allWorktimes = await Catalog.GetAll();
    
        }

        public static DateTime TrimToDateOnly(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }


    }
}
