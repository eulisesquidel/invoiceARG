using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;
using FacturaElectronica.Ui.Web.Code.Security;

namespace FacturaElectronica.Ui.Web.Code
{
    public class UIHelper
    {      
        public const string cboNullValue = "-1";

        public static CustomIdentity GetCustomIdentity()
        {
            CustomPrincipal ppal = (CustomPrincipal)HttpContext.Current.User;
            return (CustomIdentity)ppal.Identity;            
        }

        public static int? GetIntFromInputText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(text);
            }
        }

        public static long? GetLongFromInputText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            else
            {
                return Convert.ToInt64(text);
            }
        }

        public static int? GetIntFromInputCbo(DropDownList cbo)
        {
            if (cbo.SelectedIndex >= 0)
            {
                if (cbo.SelectedValue == cboNullValue)
                    return null;
                else
                    return Convert.ToInt32(cbo.SelectedValue);
            }
            else
            {
                return null;
            }
        }

        public static string GetStringFromInputCbo(DropDownList cbo)
        {
            if (cbo.SelectedIndex >= 0)
            {
                if (cbo.SelectedValue == cboNullValue)
                    return null;
                else
                    return cbo.SelectedValue;
            }
            else
            {
                return null;
            }
        }

        public static decimal? GetDecimalFromInputText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(text);
            }
        }

        public static List<int> GetIntListFromInputCbo(ListBox cbo)
        {
            List<int> selectedItems = new List<int>();
            foreach (ListItem item in cbo.Items)
            {
                if (item.Selected)
                {
                    selectedItems.Add(Convert.ToInt32(item.Value));
                }
            }

            return selectedItems;
        }

        public static char? GetCharFromInputCbo(DropDownList cbo)
        {
            if (cbo.SelectedIndex >= 0)
            {
                if (cbo.SelectedValue == cboNullValue)
                    return null;
                else
                    return Convert.ToChar(cbo.SelectedValue);
            }
            else
            {
                return null;
            }
        }

        public static DateTime? GetDateTimeFromInputText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            else
            {
                DateTime result;
                bool isParsed = DateTime.TryParseExact(text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out result);
                return isParsed ? (DateTime?)result : null;
            }
        }

        public static void LoadCbo(IList dataSource, DropDownList cbo, string extraCode, string key = "Id", string value = "Nombre")
        {
            if (!String.IsNullOrEmpty(extraCode))
            {
                cbo.Items.Add(new ListItem(extraCode, cboNullValue));
            }

            string id = string.Empty;
            string name = string.Empty;
            foreach (var dataSourceObject in dataSource)
            {
                Type type = dataSourceObject.GetType();
                id = type.GetProperty(key).GetValue(dataSourceObject, null).ToString();
                name = type.GetProperty(value).GetValue(dataSourceObject, null).ToString();
                cbo.Items.Add(new ListItem(name, id));
            }
        }

        public static void LoadCbo(IList dataSource, ListBox cbo, string extraCode, string key = "Id", string value = "Nombre")
        {
            if (!String.IsNullOrEmpty(extraCode))
            {
                cbo.Items.Add(new ListItem(extraCode, cboNullValue));
            }

            string id = string.Empty;
            string name = string.Empty;
            foreach (var dataSourceObject in dataSource)
            {
                Type type = dataSourceObject.GetType();
                id = type.GetProperty(key).GetValue(dataSourceObject, null).ToString();
                name = type.GetProperty(value).GetValue(dataSourceObject, null).ToString();
                cbo.Items.Add(new ListItem(name, id));
            }
        }

        public static void LoadBasicCbo(IList dataSource, DropDownList cbo, string extraCode)
        {                        
            if (!String.IsNullOrEmpty(extraCode))
            {
                cbo.Items.Add(new ListItem(extraCode, cboNullValue));
            }

            foreach (var item in dataSource)
            {
                cbo.Items.Add(item.ToString());
            }            
        }
    }
}