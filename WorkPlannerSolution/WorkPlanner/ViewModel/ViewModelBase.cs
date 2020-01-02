using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using WorkPlanner.Handler;
using WorkPlanner.Interface;

namespace WorkPlanner.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _errorList;



        public ViewModelBase()
        {
            _errorList = new ObservableCollection<string>();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> ErrorList
        {
            get { return _errorList; }
            set { _errorList = value; }
        }
    }
}