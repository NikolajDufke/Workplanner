using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    class MainPageViewModel
    {

        DatabaseHandler<MainPageViewModel, Employee> _dbHandler;

        public MainPageViewModel()
        {
           _dbHandler = new DatabaseHandler<MainPageViewModel, Employee>(this);
           _dbHandler.Delete(new Employee());
        }


    }
}
