using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Persistency;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    class MainPageHandler <Model> where Model : class 
    {
        private MainPageViewModel _viewModel;


        public MainPageHandler(MainPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Delete(Model type)
        {
       
            WebApiWorkPlanner<Model> executer = new WebApiWorkPlanner<Model>("http://localhost:56265/api/",   type.GetType().Name+"/" );

        }
    }
}
