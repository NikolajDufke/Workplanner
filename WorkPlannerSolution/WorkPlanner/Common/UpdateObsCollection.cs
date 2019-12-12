using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Catalog;
using WorkPlanner.Model;
using WorkPlanner.Model.Databasemodels;

namespace WorkPlanner.Common
{
    public class UpdateObsCollection
    {
        /// <summary>
        /// Gets All Employees and adds them to the observable collection
        /// </summary>
        public async void GetEmployeesAsync(ObservableCollection<Employees> Catalog)
        {
            Catalog.Clear();
            List<Employees> listE = await CatalogsSingleton.Instance.EmployeeCatalog.GetAll();
            foreach (Employees e in listE)
            {
                Catalog.Add(e);
            }
        }
    }
}
