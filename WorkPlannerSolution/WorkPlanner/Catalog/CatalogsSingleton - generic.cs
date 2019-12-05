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
        private Catalog<T> _catalog;

        private CatalogsSingletons()
        {
            Catalog<T> _catalog = new Catalog<T>();
       }

        public static CatalogsSingletons<T> Instance
        {
            get
            {
                return _instance ?? (_instance = new CatalogsSingletons<T>());
            }
        }

        #endregion

        #region Generic Catalog
        /// <summary>
        /// Et generic catalog der henter catalog klassen med objekt T
        /// </summary>
        public Catalog<T> Catalog
        {
            get { return _catalog; }

        }
        #endregion
    }
}
