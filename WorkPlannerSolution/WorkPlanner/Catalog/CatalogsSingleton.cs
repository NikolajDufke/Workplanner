using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;

namespace WorkPlanner.Catalog
{
    public class CatalogsSingleton
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



        private Catalog<EmployeeInformations> _employeeInfoCatalog;

        public Catalog<EmployeeInformations> EmployeeInfoCatalog
        {
            get
            {
                if (_employeeInfoCatalog == null)
                {
                    _employeeInfoCatalog = new Catalog<EmployeeInformations>();
                }
                return _employeeInfoCatalog;
            }

        }

        private Catalog<Users> _UsersCatalog;

        public Catalog<Users> UsersCatalog
        {
            get
            {
                if (_UsersCatalog == null)
                {
                    _UsersCatalog = new Catalog<Users>();
                }
                return _UsersCatalog;
            }

        }


        private Catalog<Employees> _employeeCatalog;

        public Catalog<Employees> EmployeeCatalog
        {
            get
            {
                if (_employeeCatalog == null)
                {
                    _employeeCatalog = new Catalog<Employees>();
                }
                return _employeeCatalog;
            }
     
        }

        private Catalog<Worktimes> _worktimeCatalog;

        public  Catalog<Worktimes> WorktimeCatalog
        {
            get
            {
                if (_worktimeCatalog == null)
                {
                    _worktimeCatalog = new Catalog<Worktimes>();
                }
                return _worktimeCatalog;
            }
           
        }

        private Catalog<Accesses> _userAccess;

        public Catalog<Accesses> UserAccess
        {
            get
            {
                if (_userAccess == null)
                {
                    _userAccess = new Catalog<Accesses>();
                }
                return _userAccess;
            }
            set { _userAccess = value; }
        }




    }
}
