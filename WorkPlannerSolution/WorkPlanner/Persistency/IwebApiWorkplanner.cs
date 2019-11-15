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
        Task Update(T obj);
        Task Create(T obj);
        Task Delete(T obj);
        Task<T> Read();
    }
}
