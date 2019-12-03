using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;
using WorkPlanner.Model.Databasemodels;
using WorkPlanner.Persistency;

namespace WorkPlanner.Catalog
{
   public class CatalogsSingletons<T> where T : DatabaseObject
    {
        #region Singleton Implementation

        private static CatalogsSingletons<T> _instance;

        private CatalogsSingletons()
        {
            Catalog<T> temp = new Catalog<T>();
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

  
    }
}
