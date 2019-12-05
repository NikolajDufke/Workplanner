using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;
using WorkPlanner.Model.Databasemodels;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Common
{
    public class PropertyNamesHelper<T> where T:class 
    {
        #region Instace fields
        private List<PropInfo> _listPropinfo;
        #endregion
        #region Constructor
        public PropertyNamesHelper()
        {
            _listPropinfo = new List<PropInfo>();
            Getpropertynames();
            IfUppercaseAddSpace();
        }

        public PropertyNamesHelper(List<int> propertiesToIgnore)
        {
            _listPropinfo = new List<PropInfo>();
            Getpropertynames(propertiesToIgnore);
            IfUppercaseAddSpace();
        }
        #endregion
        #region Properties
        public List<PropInfo> GetListOfPropinfo
        {
            get { return _listPropinfo; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adds properties from a Model to the list in this class
        /// </summary>
        /// <param name="indexToIgnore"></param>
        private void Getpropertynames(List<int> indexToIgnore = null)
        {
            if (indexToIgnore == null)
            {
                indexToIgnore = new List<int>();
            }

            int count = 0;
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                count++;
                if (indexToIgnore.Contains(count))
                {
                    continue;
                }
                PropInfo temp = new PropInfo();
                temp.PropName = propertyInfo.Name;
                _listPropinfo.Add(temp);
            }
        }
        /// <summary>
        /// Checks the values in the list in this class and goes thru each property 
        /// makes a visual property name that can be showed in the view
        /// </summary>
        private void IfUppercaseAddSpace()
        {
            foreach (PropInfo stringFromlist in _listPropinfo)
            {
                StringBuilder newString = new StringBuilder(stringFromlist.PropName.Length + 5);
                newString.Append(stringFromlist.PropName[0]);
                for (int i = 1; i < stringFromlist.PropName.Length; i++)
                {
                    if (char.IsUpper(stringFromlist.PropName[i]) && stringFromlist.PropName[i - 1] != ' ')
                    {
                        newString.Append(' ');
                        newString.Append(stringFromlist.PropName[i]);
                    }

                    if (char.IsLower(stringFromlist.PropName[i]))
                    {
                        newString.Append(stringFromlist.PropName[i]);
                    }
                }
                string toAddString = newString.ToString() + ":";
                stringFromlist.VisualName = toAddString;
            }
        }
        #endregion
    }
}
