using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Model;
using WorkPlanner.ViewModel;

namespace WorkPlanner.Handler
{
    public class PropertyNamesHandler<T>
    {
        public List<PropInfo> Getpropertynames()
        {

            List<PropInfo> listProperties = new List<PropInfo>();
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                PropInfo temp = new PropInfo();
                temp.PropName = propertyInfo.Name;
                listProperties.Add(temp);
            }

            return listProperties;
        }

        public List<PropInfo> IfUppercaseAddSpace(List<PropInfo> listOfPropName)
        {
            List<PropInfo> listOfAddedVisualName = listOfPropName;
            foreach (PropInfo stringFromDic in listOfPropName)
            {
                StringBuilder newString = new StringBuilder(stringFromDic.PropName.Length + 5);
                newString.Append(stringFromDic.PropName[0]);
                for (int i = 1; i < stringFromDic.PropName.Length; i++)
                {
                    if (char.IsUpper(stringFromDic.PropName[i]) && stringFromDic.PropName[i - 1] != ' ')
                    {
                        newString.Append(' ');
                        newString.Append(stringFromDic.PropName[i]);
                    }

                    if (char.IsLower(stringFromDic.PropName[i]))
                    {
                        newString.Append(stringFromDic.PropName[i]);
                    }
                }

                string toAddString = newString.ToString() + ":";
                stringFromDic.VisualName = toAddString;
            }
            return listOfAddedVisualName;
        }
    }
}
