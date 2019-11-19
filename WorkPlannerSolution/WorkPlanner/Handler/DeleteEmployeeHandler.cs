using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Persistency;

namespace WorkPlanner.Handler
{
    class DatabaseHandler <ViewModel, type> where type : class 
    {
        private ViewModel _ViewModel;


        public DatabaseHandler(ViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        public void Delete(type employee)
        {
            WebApiWorkPlanner<type> executer = new WebApiWorkPlanner<type>("http://localhost:56265/api/","Employee/");
        }


    }
}
