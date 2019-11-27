﻿using System;
using System.Collections.Generic;
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

        public T Populate(List<PropInfo> propInfoList,T obj)
        {
     
            foreach (var propInfo in propInfoList)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.Name == propInfo.PropName)
                    {
                        if (property.PropertyType != propInfo.ValueFromUser.GetType())
                        {

                            if (property.PropertyType == typeof(int))
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

    }
}
