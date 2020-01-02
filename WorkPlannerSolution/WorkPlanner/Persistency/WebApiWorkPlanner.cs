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
        private HttpClientHandler _clientHandler;
        private HttpClient _client;

        public WebApiWorkPlanner(string serverUrl, string apiPrefix)
        {
            _serverUrl = serverUrl + "api/";
            _apiPrefix = apiPrefix;
           
            _clientHandler = new HttpClientHandler();
            _clientHandler.UseDefaultCredentials = true;
            
            _client = new HttpClient(_clientHandler);
            _client.BaseAddress = new Uri(_serverUrl);
        }

        public async Task<T> CreateAsync(T obj)
        {       
            try
            {
                string serializedObject = JsonConvert.SerializeObject(obj);
                StringContent sc = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(_apiPrefix + "/" , sc);

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception("Create action failed.");
                }
            }
            catch (Exception e)
            {    
                throw new Exception("failed to create object");
            }
        }

       

        public async Task<bool> DeleteAsync(string apiId)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(_apiPrefix + "/" + apiId);

                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                else
                {
                    throw new Exception("Delete form db failed.");
                }
            }


            catch (Exception e)
            {
                throw new Exception("Failed to delete object");
            }

        }

        public async Task<List<T>> LoadAsync()
        {
            try
             {
                HttpResponseMessage response = await _client.GetAsync(_apiPrefix + "/");
                if (response.IsSuccessStatusCode)
                {
                    string responseContentAsString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(responseContentAsString);
                }
                else
                {
                    throw new Exception("Update to db failed.");
                }

                return null;
                
            }
            catch (Exception e)
            {
                throw new Exception("Failed to load object");
            }
        }

        public async Task<T> ReadAsync(string apiId)
        {
            
      
                HttpResponseMessage response = await _client.GetAsync(_apiPrefix + "/" + apiId);
                if (response.IsSuccessStatusCode)
                {
                    string responseContentAsString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseContentAsString);
                }
                else
                {
                    throw new Exception("Failed to read from db.");
                }

                return null;
            

        
        }

        public async Task<bool> UpdateAsync(T obj, string apiId)
        {
            try
            {
                string serializedObject = JsonConvert.SerializeObject(obj);
                StringContent sc = new StringContent(serializedObject, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(_apiPrefix + "/" + apiId, sc);

                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                else
                {
                    throw new Exception("Update to db failed.");
                }


            }
            catch (Exception e)
            {
                throw new Exception("Failed to update object");
            }
          


        }

        public async Task<bool> TestConnection()
        {
            try
            {
              
                HttpResponseMessage response = await _client.GetAsync(_apiPrefix + "/" + 1);
                if (response.IsSuccessStatusCode)
                {
                   return response.IsSuccessStatusCode;
                }

                return false;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to read object");
            }

            return false;
        }
    }
}
