using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel;
using WorkPlanner.Common;
using WorkPlanner.Handler;
using WorkPlanner.Model;

namespace WorkPlanner.ViewModel
{
    public class MainPageViewModel
    {

        private ObservableCollection<WorktimeEventDetails> _eventElements;
        private DateTime _date;
        private MainPageHandler _handler;
        private ICommand _checkinChectOutCommand;

        public MainPageViewModel()
        {
            _eventElements = new ObservableCollection<WorktimeEventDetails>();
            _handler = new MainPageHandler(this);

        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public ObservableCollection<WorktimeEventDetails> Worktimes
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

    }
}
