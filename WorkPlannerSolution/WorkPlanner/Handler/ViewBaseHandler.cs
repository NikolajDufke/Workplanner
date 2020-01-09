using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Interface;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{


   public class ViewBaseHandler
    {
        protected IViewModelBase _viewModelBase;

        public ViewBaseHandler(IViewModelBase viewmodel)
        {
            _viewModelBase = viewmodel;
        }

        protected void AddErrorMessage(string message)
        {
            _viewModelBase.ErrorList.Add(message);
        }

        protected void RemoveErrorMessage(string message)
        {
            _viewModelBase.ErrorList.Remove(message);
        }
    }
}
