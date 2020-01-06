using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel;
using WorkPlanner.Common;
using WorkPlanner.Handler;
using WorkPlanner.Interface;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class MainPageViewModel :ViewModelBase , IWorkTimeEventDetailObserver
    {

        private ObservableCollectionPropertyNotify<WorktimeEventDetails> _eventElements;
        private DateTime _date;
        private MainPageHandler _handler;
        private ICommand _checkinChectOutCommand;
        private ICommand _hamburgerButton_CheckedCommand;
        private ICommand _navigateToUserCommand;
        private ICommand _nagigateToAdminCommand;
        public MainPageViewModel()
        {
            _eventElements = new ObservableCollectionPropertyNotify<WorktimeEventDetails>();
            _handler = new MainPageHandler(this);

        }


        private bool _hamburgerButton_Checked;

        public ICommand HamburgerButton_CheckedCommand
        {
            get
            {
                return _hamburgerButton_CheckedCommand ?? 
                       (_hamburgerButton_CheckedCommand =
                    new RelayCommand(_handler.HamburgerButton_Checked));
            }
            set { _hamburgerButton_CheckedCommand = value; }

        }

        public ICommand NavigateToUserCommand
        {
            get
            {
                return _navigateToUserCommand ??
                       (_navigateToUserCommand =
                           new RelayCommand(_handler.NavigateToUser));
            }
            set { _navigateToUserCommand = value; }

        }

        public ICommand NagigateToAdminCommand
        {
            get
            {
                return _nagigateToAdminCommand ??
                       (_nagigateToAdminCommand =
                           new RelayCommand(_handler.NagigateToAdmin));
            }
            set { _nagigateToAdminCommand = value; }

        }



        private bool _isPaneOpen;

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set
            {
                _isPaneOpen = value; 
                OnPropertyChanged();
            }
        }


        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public ObservableCollectionPropertyNotify<WorktimeEventDetails> Worktimes
        {
            get { return _eventElements; }
            set { _eventElements = value; }
        }

        public ICommand CheckinChectOutCommand
        {
            get
            {
                return _checkinChectOutCommand ?? (_checkinChectOutCommand =
                           new RelayArgCommand<int>(ev => _handler.CheckinChectOut(ev)));
            }
        }

        public void Update(Worktimes worktime)
        {
            Worktimes.Refresh();
            
        }
    }


    public class ObservableCollectionPropertyNotify<T> : ObservableCollection<T>
    {
       
        public void Refresh()
        {
            for (var i = 0; i < this.Count(); i++)
            {
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
    }
}
