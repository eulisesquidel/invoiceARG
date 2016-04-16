using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;
using System.Reflection;
using Web.Framework.Misc;
using Web.Framework.Enum;

namespace WebFramework
{
    public class UIWebHelper
    {
        public const string cboNullValue = "-1";

        public static void BindDateTime(TextBox textBox, DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                textBox.Text = dateTime.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                textBox.Text = string.Empty;
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

        public static long? GetLongFromInputCbo(DropDownList cbo)
        {
            if (cbo.SelectedIndex >= 0)
            {
                if (cbo.SelectedValue == cboNullValue)
                    return null;
                else
                    return Convert.ToInt64(cbo.SelectedValue);
            }
            else
            {
                return null;
            }
        }

        public static int? GetIntFromInputText(TextBox textbox)
        {
            if (String.IsNullOrEmpty(textbox.Text))
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(textbox.Text);
            }
        }

        public static long? GetLongFromInputText(TextBox textbox)
        {
            if (String.IsNullOrEmpty(textbox.Text))
            {
                return null;
            }
            else
            {
                return Convert.ToInt64(textbox.Text);
            }
        }

        public static Decimal? GetDecimalFromInputText(TextBox textbox)
        {
            if (String.IsNullOrEmpty(textbox.Text))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(textbox.Text);
            }
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

        public static List<int> GetIntFromInputLst(ListBox lst)
        {
            List<int> selectedValues = new List<int>();
            foreach (ListItem item in lst.Items)
            {
                if (item.Selected)
                {
                    selectedValues.Add(Convert.ToInt32(item.Value));
                }
            }

            return selectedValues;
        }

        public static List<long> GetIntFromInputChkLst(RadioButtonList lst)
        {
            List<long> selectedValues = new List<long>();
            foreach (ListItem item in lst.Items)
            {
                if (item.Selected)
                {
                    selectedValues.Add(Convert.ToInt64(item.Value));
                }
            }

            return selectedValues;
        }

        public static List<string> GetStrFromInputLst(ListBox lst)
        {
            List<string> selectedValues = new List<string>();
            foreach (ListItem item in lst.Items)
            {
                if (item.Selected)
                {
                    selectedValues.Add(item.Value);
                }
            }

            return selectedValues;
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

        public static DateTime? GetDateTimeFromInputText(TextBox textbox)
        {
            if (String.IsNullOrEmpty(textbox.Text))
            {
                return null;
            }
            else
            {
                DateTime result;
                bool isParsed = DateTime.TryParseExact(textbox.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out result);
                return isParsed ? (DateTime?)result : null;
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
            cbo.Items.Clear();
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

        public static void LoadCboRange(int fromNro, int toNro, DropDownList cbo, string extraCode)
        {
            cbo.Items.AddRange(FillRange(fromNro, toNro, extraCode));
        }

        public static void LoadLstRange(int fromNro, int toNro, ListBox lst, string extraCode = "")
        {
            lst.Items.AddRange(FillRange(fromNro, toNro, extraCode));
        }

        public static ListItem[] FillRange(int fromNro, int toNro, string extraCode)
        {
            List<ListItem> collection = new List<ListItem>();
            if (!String.IsNullOrEmpty(extraCode))
            {
                collection.Add(new ListItem(extraCode, cboNullValue));
            }

            string id = string.Empty;
            string name = string.Empty;
            int i;
            for (i = fromNro; i <= toNro; i++)
            {
                collection.Add(new ListItem(i.ToString(), i.ToString()));
            }

            return collection.ToArray();
        }

        public static void LoadLst(IList dataSource, ListBox lst, string extraCode = "", string key = "Id", string value = "Nombre", bool allDisabled = false)
        {
            lst.Items.Clear();
            if (!String.IsNullOrEmpty(extraCode))
            {
                lst.Items.Add(new ListItem(extraCode, cboNullValue));
            }

            string id = string.Empty;
            string name = string.Empty;
            foreach (var dataSourceObject in dataSource)
            {
                Type type = dataSourceObject.GetType();
                id = type.GetProperty(key).GetValue(dataSourceObject, null).ToString();
                name = type.GetProperty(value).GetValue(dataSourceObject, null).ToString();
                ListItem item = new ListItem(name, id);
                if (allDisabled)
                {
                    item.Enabled = false;
                }

                lst.Items.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Un tipo de enum</typeparam>
        /// <param name="cbo"></param>
        /// <param name="extraCode"></param>
        public void LoadEstados<T>(DropDownList cbo, string extraCode = "")
        {
            var enumValues = System.Enum.GetValues(typeof(T));
            List<KeyValuePair<int, string>> estados = new List<KeyValuePair<int, string>>();

            foreach (var enumValue in enumValues)
            {
                estados.Add(new KeyValuePair<int, string>((int)enumValue, GetEnumDescription((T)enumValue)));
            }

            LoadCbo(estados, cbo, extraCode, "Key", "Value");
        }

        public void LoadEstados<T>(ListBox lst, string extraCode = "")
        {
            var enumValues = System.Enum.GetValues(typeof(T));
            List<KeyValuePair<int, string>> estados = new List<KeyValuePair<int, string>>();

            foreach (var enumValue in enumValues)
            {
                estados.Add(new KeyValuePair<int, string>((int)enumValue, GetEnumDescription((T)enumValue)));
            }

            LoadLst(estados, lst, extraCode, "Key", "Value");
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
                    return ((DescriptionKey)attrs[0]).Text;
            }

            return en.ToString();
        }

        public static void LoadCboMonth(DropDownList cbo, string extraCode)
        {
            cbo.Items.AddRange(FillMonthCollection(extraCode));
        }

        public static void LoadLstMonth(ListBox lst, string extraCode = "")
        {
            lst.Items.AddRange(FillMonthCollection(extraCode));
        }

        public static ListItem[] FillMonthCollection(string extraCode)
        {
            List<ListItem> collection = new List<ListItem>();

            if (!String.IsNullOrEmpty(extraCode))
            {
                collection.Add(new ListItem(extraCode, cboNullValue));
            }

            for (int i = 1; i < 13; i++)
            {
                string istr = i.ToString();
                collection.Add(new ListItem("Mes " + istr, istr));
            }

            return collection.ToArray();
        }

        internal static bool IsItemSelected(ListBox listBox, int index)
        {
            string indexStr = index.ToString();
            bool isSelected = false;
            foreach (ListItem item in listBox.Items)
            {
                if (item.Value == indexStr)
                {
                    isSelected = item.Selected;
                }

                if (isSelected)
                {
                    break;
                }
            }

            return isSelected;
        }

        public static void SelectListBoxFromList(ListBox lst, List<int> selectedList)
        {
            foreach (ListItem li in lst.Items)
            {
                if (selectedList.Where(i => i.ToString() == li.Value).Count() > 0)
                {
                    li.Selected = true;
                }
            }
        }

    }
}
