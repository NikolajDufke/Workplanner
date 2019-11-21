using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;
using WorkPlanner.Persistency;

namespace WorkPlanner.Catalog
{
    class EmployeeCatalogSingleton
    {
        

        #region instanceFields

        private WebApiWorkPlanner<Employee> _api;
        private const string _serverurl = "http://localhost:56265/";
        private const string _apiprefix = "Employee";
        private ObservableCollection<Employee> _collectionOfAll;

        #endregion


        #region Singleton implementation

        private EmployeeCatalogSingleton _instance;

        private EmployeeCatalogSingleton()
        {
          
            _api = new WebApiWorkPlanner<Employee>(_serverurl,_apiprefix);
        }

        public EmployeeCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new EmployeeCatalogSingleton()); }
       
        }

        #endregion
        

        public ObservableCollection<Employee> AllEmployeeCollection
        {
            get
            {
                if (_collectionOfAll == null)
                {
                    LoadEmployeesFromDB();
                }
                return _collectionOfAll;
            }
        }



        public async void Remove(Employee e)
        {

            if (e != null)
            {
                _collectionOfAll.Remove(e);
                //bool result = await _api.CreateAsync(e););
                //if (result = true)
                //{
                //    LoadFile();
                //}

            }
        }




        #region HelperMethods

        private async void AddEmployeeToDb(Employee e)
        {
           
            LoadEmployeesFromDB();

        }


        private async void LoadEmployeesFromDB()
        {
            if (_collectionOfAll == null)
            {
                _collectionOfAll = new ObservableCollection<Employee>();
            }

            try
            {
                List<Employee> LoadedList = await _api.LoadAsync();

                if (LoadedList != null)
                {
                    _collectionOfAll.Clear();
                    foreach (Employee item in LoadedList)
                    {
                        _collectionOfAll.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to load employees from db.");
            }

        }
        #endregion

    }
}
