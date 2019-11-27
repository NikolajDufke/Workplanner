using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;
using WorkPlanner.Persistency;

namespace WorkPlanner.Catalog
{
    class CatalogsSingletons<T> where T : class
    {
        #region Singleton Implementation

        private static CatalogsSingletons<T> _instance;

        private CatalogsSingletons()
        {
            Catalog<T> temp = new Catalog<T>();
            bool t = TestConnection(temp).Result;

            if (t)
                _catalog = temp;
            else
                throw new Exception("Catalog " + typeof(T).Name + " does not exist");
        }

        public static CatalogsSingletons<T> Instance
        {
            get
            {
                return
                    _instance ?? (_instance = new CatalogsSingletons<T>());
            }
        }

        #endregion

        private Catalog<T> _catalog;

        public Catalog<T> Catalog
        {
            get { return _catalog; }

        }

        private async Task<bool> TestConnection(Catalog<T> catalogToTest)
        {
            return await catalogToTest.TestConnection();
        }
    }
}
