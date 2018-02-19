using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Pheko.Common.UtilityComponent
{
    public class Utility
    {
        public static void BindObject<T>(T dataObject, DataSet dataSet)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                foreach (DataColumn column in dataSet.Tables[0].Columns)
                {
                    Type type = dataObject.GetType();
                    PropertyInfo info = type.GetProperty(column.ColumnName);
                    if (info == null) { break; }

                    if (!Convert.IsDBNull(row[column.ColumnName]))
                    {
                        info.SetValue(dataObject, Convert.ChangeType(row[column.ColumnName], info.PropertyType), null);
                    }
                }
            }
        }

        public static List<T> ConvertDataTableToObjectList<T>(DataTable dataTable)
        {
            List<T> returnList = new List<T>();
            Type type = typeof(T);

            foreach (DataRow row in dataTable.Rows)
            {
                T dataObject = (T)Activator.CreateInstance(type);

                foreach (DataColumn column in dataTable.Columns)
                {
                    PropertyInfo info = type.GetProperty(column.ColumnName);

                    if (info != null)
                    {
                        if (!Convert.IsDBNull(row[column.ColumnName]))
                        {
                            if (IsNullable(info.PropertyType))
                            {
                                info.SetValue(dataObject, Convert.ChangeType(row[column.ColumnName], Nullable.GetUnderlyingType(info.PropertyType)), null);
                            }
                            else
                            {
                                info.SetValue(dataObject, Convert.ChangeType(row[column.ColumnName], info.PropertyType), null);
                            }
                        }
                    }

                }

                returnList.Add(dataObject);
            }

            return returnList;

        }

        public static T ConvertDataRowToObject<T>(DataRow dataRow)
        {
            Type type = typeof(T);
            T returnObject = (T)Activator.CreateInstance(type);
            PropertyInfo[] typeProperties = type.GetProperties();

            foreach (PropertyInfo property in typeProperties)
            {
                if (dataRow.Table.Columns.Contains(property.Name) && !Convert.IsDBNull(dataRow[property.Name]))
                {
                    if (IsNullable(property.PropertyType))
                    {
                        property.SetValue(returnObject, Convert.ChangeType(dataRow[property.Name], Nullable.GetUnderlyingType(property.PropertyType)), null);
                    }
                    else
                    {
                        property.SetValue(returnObject, Convert.ChangeType(dataRow[property.Name], property.PropertyType), null);
                    }
                }
            }

            return returnObject;
        }

        public static bool IsNullable(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

    }
}
