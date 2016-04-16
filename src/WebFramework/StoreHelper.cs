using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web;

namespace Web.Framework.Misc
{
    public class StoreHelper
    {
        public static void StoreObject(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public static object GetObject(string key)
        {
            return HttpContext.Current.Session[key];
        }
    }
}
