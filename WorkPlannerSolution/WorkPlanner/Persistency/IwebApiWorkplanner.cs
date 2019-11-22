using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace WorkPlanner.Persistency
{
   public interface IwebApiWorkplanner<T>
    {
        Task<List<T>> LoadAsync();
        Task<bool> UpdateAsync(T obj,string apiId);
        Task<T> CreateAsync(T obj);
        Task<bool> DeleteAsync(string apiId);
        Task<T> ReadAsync(string apiId);
    }
}
