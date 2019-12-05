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
using WorkPlanner.ViewModel;

namespace WorkPlanner.ViewModel
{
    public class CreateEmployeeViewModel : ViewModelBase
    {
        #region Instace fields
        private ObservableCollection<PropInfo> _propEmployeeInfoList;
        private ObservableCollection<PropInfo> _propUsersInfoList;
        private Handler.CreateEmployeeHandler _createEmployeeHandler;
        private ICommand _createEmployeeCommand;
        private string _message;
        #endregion
        #region Constructor

        public CreateEmployeeViewModel()
        {
            _createEmployeeHandler = new CreateEmployeeHandler(this);
            CreateEmployeeCommand = new RelayCommand(_createEmployeeHandler.CreateEmployee);
            _propEmployeeInfoList = new ObservableCollection<PropInfo>();
            _propUsersInfoList = new ObservableCollection<PropInfo>();
            _createEmployeeHandler.PopulatePrepInfo();
        }

        #endregion
        #region Properties



        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateEmployeeCommand
        {
            get
            {
                return _createEmployeeCommand ??
                       (_createEmployeeCommand = new RelayCommand(_createEmployeeHandler.CreateEmployee));
            }
            set { _createEmployeeCommand = value; }
        }

        #endregion
        #region Observablecollections
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
    }
}

