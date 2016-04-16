using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Framework.Misc
{
    public static class CompareString
    {
        public static bool AreEqual(string a, string b)
        {
            if (a == null)
                a = string.Empty;

            if (b == null)
                b = string.Empty;

            return string.Compare(a, b, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}
