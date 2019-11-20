using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class CreateEmployeeViewModel
    {
        private ObservableCollection<PropInfo> _propinfolist;
        public CreateEmployeeViewModel()
        {
        PropertyNamesHandler<EmployeeInformation> getPropertiesHandler = new PropertyNamesHandler<EmployeeInformation>();
        List<PropInfo> employeeIPropList = getPropertiesHandler.Getpropertynames();
        List<PropInfo> textNameList = getPropertiesHandler.IfUppercaseAddSpace(employeeIPropList);
        }

        public ObservableCollection<PropInfo> PropInfoList
        {
            get { return _propinfolist;}
            set { _propinfolist = value; }
        }
    }
}
