using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Common;
using WorkPlanner.Interface;

namespace WorkPlanner.Factories
{
    /// <summary>
    /// A factory that creates objects of PropertyNamesHelper and PropertyPopulator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    static class PropertyHelpersFactory <T> where T : class
    {
        public static PropertyNamesHelper<T> PropertyNamesFactory()
        {
            return new PropertyNamesHelper<T>();
        }

        public static PropertyNamesHelper<T> PropertyNamesFactory(List<int> propertiesToIgnore)
        {
            return new PropertyNamesHelper<T>(propertiesToIgnore);
        }

        public static Ipopulator<T> PopulatorFactory()
        {
            return new PropertyPopulator<T>();
        }

    }
}
