using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Handler
{
    class GetPropertyNamesHandler<T>
    {
        public GetPropertyNamesHandler(T obj)
        {
            var Props = obj.GetType().GetProperties();
        }
    }
}
