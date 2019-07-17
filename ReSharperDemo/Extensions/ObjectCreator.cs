using System;
using System.Collections.Generic;
using System.Data;

namespace ReSharperDemo.Extensions
{
    public class ObjectCreator
    {
        public static T CreateInstance<T>(DataTable data)
        {
            if (data.Rows.Count > 0)
            {
                var type = typeof(T);
                var newInstance = Activator.CreateInstance(type);

                foreach (var propertyInfo in type.GetProperties())
                {
                    var propertyName = propertyInfo.Name;

                    bool canSetProperty = !propertyInfo.PropertyType.IsClass;

                    if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType.Name == "String")
                        canSetProperty = true;

                    if (canSetProperty)
                    {
                        if (data.Columns.Contains(propertyName))
                            propertyInfo.SetValue(newInstance, Convert.ChangeType(data.Rows[0][propertyName], propertyInfo.PropertyType), null);
                    }
                }

                data.Dispose();
                data = null;

                return (T)newInstance;
            }
            else
                return default(T);
        }

        public static List<T> CreateInstances<T>(DataTable data)
        {
            var type = typeof(T);
            var newList = new List<T>();

            foreach (DataRow dataRow in data.Rows)
            {
                var newInstance = Activator.CreateInstance(type);

                foreach (var propertyInfo in type.GetProperties())
                {
                    var propertyName = propertyInfo.Name;

                    bool canSetProperty = !propertyInfo.PropertyType.IsClass;

                    if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType.Name == "String")
                        canSetProperty = true;

                    if (canSetProperty)
                    {
                        if (data.Columns.Contains(propertyName))
                            propertyInfo.SetValue(newInstance, Convert.ChangeType(dataRow[propertyName] ?? "", propertyInfo.PropertyType), null);
                    }
                }

                newList.Add((T)newInstance);
            }
            data.Dispose();
            data = null;

            return newList;
        }
    }
}