using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkPlanner.Persistency 
{
    public class WebApiWorkPlanner<T> : IwebApiWorkplanner<T> where T : class
    {
        private string _serverUrl;
        private string _apiPrefix;
        private string _apiID;
        private HttpClientHandler _clientHandler;
        private HttpClient _client;

        public WebApiWorkPlanner(string serverUrl, string apiPrefix, string apiId)
        {
            _serverUrl = serverUrl;
            _apiPrefix = apiPrefix;
            _apiID = apiId;
            _clientHandler = new HttpClientHandler();
            _clientHandler.UseDefaultCredentials = true;
            
            _client = new HttpClient(_clientHandler);
            _client.BaseAddress = new Uri(_serverUrl);
        }

        public async Task Create(T obj)
        {
         
            try
            {
                string serializedObject = JsonConvert.SerializeObject(obj);
                StringContent sc = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(_apiPrefix + " / " + _apiID, sc);
            }
            catch (Exception e)
            {   
                
                throw new Exception("creation failed");
            }


        }

        public Task Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Load()
        {
            throw new NotImplementedException();
        }

        public Task<T> Read()
        {
            throw new NotImplementedException();
        }



        public Task Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
