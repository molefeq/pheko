using System;

namespace Pheko.DataAccess.Utility
{
    public class DbConverter
    {
        public static object ToDbInteger(object objectValue)
        {
            if (objectValue == null)
            {
                return DBNull.Value;
            }

            int intValue = Convert.ToInt32(objectValue);

            if (intValue == int.MinValue)
            {
                return DBNull.Value;
            }

            return intValue;
        }

        public static object ToDbDecimal(object objectValue)
        {
            if (objectValue == null)
            {
                return DBNull.Value;
            }

            decimal decimalValue = Convert.ToDecimal(objectValue);

            if (decimalValue == decimal.MinValue)
            {
                return DBNull.Value;
            }

            return decimalValue;
        }

        public static object ToDbGuid(object objectValue)
        {
            if (objectValue == null)
            {
                return DBNull.Value;
            }

            Guid guidValue = string.IsNullOrEmpty(objectValue.ToString()) ? Guid.Empty : new Guid(objectValue.ToString());

            if (guidValue == Guid.Empty)
            {
                return DBNull.Value;
            }

            return guidValue;
        }

        public static object ToDbString(object objectValue)
        {
            if (objectValue == null)
            {
                return DBNull.Value;
            }

            string stringValue = objectValue.ToString();

            if (string.IsNullOrEmpty(stringValue))
            {
                return DBNull.Value;
            }

            return stringValue;
        }

        public static object ToDbDateTime(object objectValue)
        {
            if (objectValue == null)
            {
                return DBNull.Value;
            }

            DateTime dateTimeValue = DateTime.Parse(objectValue.ToString());

            if (dateTimeValue == DateTime.MinValue)
            {
                return DBNull.Value;
            }

            return dateTimeValue;
        }
    }
}
