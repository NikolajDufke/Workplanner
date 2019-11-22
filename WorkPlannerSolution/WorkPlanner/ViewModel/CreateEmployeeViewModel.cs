using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkPlanner.Common;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class CreateEmployeeViewModel
    {
        private ObservableCollection<PropInfo> _propEmployeeInfoList;
        private ObservableCollection<PropInfo> _propUsersInfoList;
        private Handler.CreateEmployeeHandler _createEmployeeHandler;
        private ICommand _createEmployeeCommand;

        #region Constructor
        public CreateEmployeeViewModel()
        {
            _propEmployeeInfoList = new ObservableCollection<PropInfo>();
            _propUsersInfoList = new ObservableCollection<PropInfo>();
            _createEmployeeHandler = new CreateEmployeeHandler(this);
            CreateEmployeeCommand = new RelayCommand(_createEmployeeHandler.CreateEmployee);

            foreach (var empProp in new PropertyNamesHelper<EmployeeInformation>().GetListOfPropinfo)
            {
                _propEmployeeInfoList.Add(empProp);
            }

            foreach (var userProp in new PropertyNamesHelper<Users>().GetListOfPropinfo)
            {
                _propUsersInfoList.Add(userProp);
            }

            
        }
        #endregion

        #region Properties

        public ObservableCollection<PropInfo> PropEmployeeInfoList
        {
            get { return _propEmployeeInfoList; }
            set { _propEmployeeInfoList = value; }
        }

        public ObservableCollection<PropInfo> PropUsersInfoList
        {
            get { return _propUsersInfoList; }
            set { _propUsersInfoList = value; }
        }

        #endregion

        public ICommand CreateEmployeeCommand
        {
            get { return _createEmployeeCommand ?? (_createEmployeeCommand = new RelayCommand(_createEmployeeHandler.CreateEmployee)); }
            set { _createEmployeeCommand = value; }
        }

     
    }
}
