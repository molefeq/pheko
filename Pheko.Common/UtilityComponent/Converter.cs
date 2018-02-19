using System;
using System.Globalization;

namespace Pheko.Common.UtilityComponent
{
    public class Converter
    {
        public static string DateTimeToString(DateTime? dateValue)
        {
            return dateValue == null ? string.Empty : dateValue.Value.ToString(Constants.DATETIME_FORMAT);
        }

        public static string DateToString(DateTime? dateValue)
        {
            return dateValue == null ? string.Empty : dateValue.Value.ToString(Constants.DATE_FORMAT);
        }

        public static DateTime? StringToDateTime(string dateText)
        {
            DateTime? dateTime = null;
            DateTime date;

            if (!string.IsNullOrEmpty(dateText) && DateTime.TryParseExact(dateText, Constants.DATETIME_FORMAT, CultureInfo.CurrentUICulture, DateTimeStyles.None, out date))
            {
                dateTime = date;
            }

            return dateTime;
        }

        public static DateTime? StringToDate(string dateText)
        {
            DateTime? dateTime = null;
            DateTime date;

            if (!string.IsNullOrEmpty(dateText) && DateTime.TryParseExact(dateText, Constants.DATE_FORMAT, CultureInfo.CurrentUICulture, DateTimeStyles.None, out date))
            {
                dateTime = date;
            }

            return dateTime;
        }
    }
}
