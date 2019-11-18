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
                
                throw new Exception("failed to create object");
            }


        }

        public async Task Delete(T obj)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(_apiPrefix + "/" + _apiID);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to delete object");
            }

        }

        public async Task<List<T>> Load()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_apiPrefix);
                if (response.IsSuccessStatusCode)
                {
                    string responseContentAsString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(responseContentAsString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to load object");
            }
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
