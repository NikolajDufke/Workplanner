using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;

namespace WorkPlanner.Interface
{
    interface Ipopulator<T> where T : class
    {
        T Populate(List<PropInfo> propInfoList, T obj);

    }
}
