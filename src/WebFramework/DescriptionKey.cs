using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Web.Framework.Translate;

namespace Web.Framework.Enum
{
    public class DescriptionKey : Attribute
    {
        public string Text;
        public DescriptionKey(string text)
        {

            Text = text;
        }

        public static string GetEnumDescription(object enumParam)
        {
            System.Enum en = (System.Enum)enumParam;
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionKey), false);

                if (attrs != null && attrs.Length > 0)
                    return LocalizationProvider.Instance[((DescriptionKey)attrs[0]).Text];
            }

            return en.ToString();
        }
    }
}
