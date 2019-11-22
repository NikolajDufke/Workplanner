using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;

namespace WorkPlanner.Catalog
{
    class CatalogsSingleton
    {
        #region Singleton Implementation
        private static CatalogsSingleton _instance;

        private CatalogsSingleton()
        {
        }

        public static CatalogsSingleton Instance
        {
            get { return _instance ?? (_instance = new CatalogsSingleton()); }
        }


        #endregion

        private Catalog<Employee> _employeeCatalog;

        public Catalog<Employee> EmployeeCatalog
        {
            get
            {
                if (_employeeCatalog == null)
                {
                    _employeeCatalog = new Catalog<Employee>();
                }
                return _employeeCatalog;
            }
     
        }

        private Catalog<Worktime> _worktimeCatalog;

        public  Catalog<Worktime> WorktimeCatalog
        {
            get
            {
                if (_worktimeCatalog == null)
                {
                    _worktimeCatalog = new Catalog<Worktime>();
                }
                return _worktimeCatalog;
            }
           
        }



    }
}
