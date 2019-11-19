using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    class GetPropertyNamesHandler<T>
    {
        public static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object obj)
        {
            return from prop in obj.GetType().GetProperties()
                where prop.PropertyType == typeof(T)
                select new KeyValuePair<string, T>(prop.Name, (T) prop.GetValue(obj));
        }
    }
}
