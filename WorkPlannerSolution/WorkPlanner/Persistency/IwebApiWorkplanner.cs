using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkPlanner.Persistency
{
   public interface IwebApiWorkplanner<T>
    {
        Task<List<T>> Load();
        Task Update(T obj,string apiId);
        Task Create(T obj);
        Task Delete(string apiId);
        Task<T> Read(string apiId);
    }
}
