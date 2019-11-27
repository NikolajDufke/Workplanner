using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Common
{
    public class PropertyNamesHelper<T> where T:class 
    {
        private List<PropInfo> _listPropinfo;

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

        public List<PropInfo> GetListOfPropinfo
        {
            get { return _listPropinfo; }
        }

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
    }
}
