using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Model
{
    class Columns
    {

        private List<Row> _rows;

        public List<Row> Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }


        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }


        private List<Worktimes> _worktimes;
        public List<Worktimes> WorkTime
        {
            get { return _worktimes; }
            set { _worktimes = value; }
        }


        

    }
}
