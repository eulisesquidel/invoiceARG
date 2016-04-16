using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace FacturaElectronica.Core.Helpers
{
    public class DateTimeHelper
    {
        public static DateTime ConvertyyyyMMddToDate(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
        }
        public static DateTime ConvertyyyyMMddhhmmssToDate(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }

    }
}
