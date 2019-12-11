using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;
using WorkPlanner.Model.Databasemodels;
using WorkPlanner.Persistency;

namespace WorkPlanner.Catalog
{
    public class Catalog<T> where T : DatabaseObject
    {

        #region Instance
        private List<T> _allCollection;
        private WebApiWorkPlanner<T> _api;
        private const string _serverurl = "http://localhost:56265/";
        private string _apiprefix ;       
        #endregion

        #region Constructor
        public Catalog()
        {
            _allCollection = new List<T>();
            _apiprefix = typeof(T).Name;
            _api = new WebApiWorkPlanner<T>(_serverurl, _apiprefix);
        }
        #endregion

        #region Proberties
  
        public async Task<List<T>> GetAll()
        {
            TimeSpan timePassed = new TimeSpan(0,0,0);


            if (_allCollection.Count != 0)
                return _allCollection;

            await LoadFromDB();

            while (_allCollection.Count == 0)
            {
                
                if (_allCollection.Count != 0)
                    return _allCollection;

               
                Task.Delay(TimeSpan.FromSeconds(5));
                timePassed = timePassed +TimeSpan.FromSeconds(5);

                if(timePassed > TimeSpan.FromSeconds(30))
                { break;}

            }
            return _allCollection;
        }
        #endregion

        #region Methods
        /// <summary>
        /// En metode der gør at man kan update async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        public async void UpdateAsync(T obj, string id)
        {
            bool result = await _api.UpdateAsync(obj, id);

            if (result == true)
            {
                await LoadFromDB();
            }
        }

        /// <summary>
        /// En metode der gør at man kan remove async
        /// </summary>
        /// <param name="id"></param>
        public async Task RemoveAsync(string id)
        {

            if (id != null)
            {

                bool result = await _api.DeleteAsync(id);
                if (result == true)
                {
                   await LoadFromDB();
                }

            }
        }

        /// <summary>
        /// En metode der gør at man kan add async
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T obj)
        {
            T result = await _api.CreateAsync(obj);

            //TODO Gør så den ikke altid går igennem(Måske en bool inde i _api) result != null vil altid gå op
            if (result != null)
            {
                await LoadFromDB();
                return result;

            }

            return null;

        }

        /// <summary>
        /// En metode der gør at man kan GetSingle async.
        /// Denne metode gør at man får et objekt ud fra id'et.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetSingleAsync(string id)
        {
            

            T result = await _api.ReadAsync(id);

            if (result != null)
            {
               await LoadFromDB();
                return result;

            }

            return null;
        }

        #endregion

        #region HelperMethods
        /// <summary>
        /// En hjælpe metode der loader data fra databasen
        /// </summary>
        private async Task LoadFromDB()
        {
            try
            {
                List<T> LoadedList = await _api.LoadAsync();

                if (LoadedList != null)
                {
                    _allCollection.Clear();
                    foreach (T item in LoadedList)
                    {
                        _allCollection.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to load " + _apiprefix + " from db.");
            }

        }

        #endregion

    }

}

