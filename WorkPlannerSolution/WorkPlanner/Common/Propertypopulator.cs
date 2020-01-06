using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.Interface;
using WorkPlanner.Model;

namespace WorkPlanner.Common
{
    class PropertyPopulator<T> : Ipopulator<T> where T : class
    {
        #region Methods
        /// <summary>
        /// Adds the properties from propinfo list into a object of obj
        /// </summary>
        /// <param name="propInfoList"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Populate(List<PropInfo> propInfoList, T obj)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var propInfo in propInfoList)
            {
                foreach (PropertyInfo property in properties)
                {
                    if (property.Name == propInfo.PropName)
                    {
                        if (property.PropertyType != propInfo.ValueFromUser.GetType())
                        {

                            if (property.PropertyType == typeof(int?) || property.PropertyType == typeof(int))
                            {
                                int temp;
                                if (Int32.TryParse(propInfo.ValueFromUser, out temp))
                                {
                                    property.SetValue(obj, temp);
                                    break;
                                }
                            }
                            else
                            {
                                throw new Exception("Type missmatch");
                            }
                        }
                        else
                        {
                            property.SetValue(obj, propInfo.ValueFromUser);
                            break;
                        }

                    }
                }
            }

            return obj;
        }
        /// <summary>
        /// Returns a list<propinfo> with propname = the name of the object 
        /// </summary>
        /// <param name="propInfoList"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ObservableCollection<PropInfo> Repopulate(ObservableCollection<PropInfo> propInfoList, T obj)
        {

            Type T = obj.GetType();

            foreach (var propInfo in propInfoList)
            {
                PropertyInfo prop = T.GetProperty(propInfo.PropName);
                if (prop != null)
                {
                    propInfo.ValueFromUser = prop.GetValue(obj).ToString();
                }
            }

            return propInfoList;
        }
        #endregion
    }
}
