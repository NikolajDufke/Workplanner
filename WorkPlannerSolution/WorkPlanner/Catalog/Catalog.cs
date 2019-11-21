﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;
using WorkPlanner.Persistency;

namespace WorkPlanner.Catalog
{
    public class Catalog<T> where T : class
    {

        private ObservableCollection<T> _allCollection;
        private WebApiWorkPlanner<T> _api;
        private const string _serverurl = "http://localhost:56265/";
        private string _apiprefix ;


        public Catalog()
        {
            _apiprefix = typeof(T).Name;
            _api = new WebApiWorkPlanner<T>(_serverurl, _apiprefix);
        }

        #region Proberties

        public ObservableCollection<T> GetAll
        {
            get
            {
                if (_allCollection == null)
                {
                    LoadFromDB();
                }
                return _allCollection;
            }
        }

        #endregion

        #region Methods

        public async void UpdateAsync(T obj, string id)
        {
             bool result = await _api.UpdateAsync(obj, id);

            if (result = true)
            {
                LoadFromDB();
            }

        }


        public async void RemoveAsync(string id)
        {

            if (id != null)
            {

                bool result =  await _api.DeleteAsync(id);
                if (result = true)
                {
                    LoadFromDB();
                }

            }
        }

        public async void AddAsync(T obj)
        {
            bool result = await _api.CreateAsync(obj);

            if (result)
            {
                LoadFromDB();
            }
        }

        #endregion

        #region HelperMethods

        private async void LoadFromDB()
        {
            if (_allCollection == null)
            {
                _allCollection = new ObservableCollection<T>();
            }

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
}