using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFramework.Mapper
{
    public static class EntityMapper
    {
        public static void Map(object origen, object destino, params string[] propiedadesAOmitir)
        {
            Type torigen = origen.GetType();
            Type tdestino = destino.GetType();

            PropertyInfo[] destinoProperties = tdestino.GetProperties();

            Dictionary<string, PropertyInfo> origenProperties = torigen.GetProperties().ToDictionary(p => p.Name);

            bool procesar = false;
            foreach (PropertyInfo piDestino in destinoProperties)
            {
                string destinoPropName = piDestino.Name;
                procesar = true;
                if (propiedadesAOmitir != null)
                {
                    procesar = !propiedadesAOmitir.Contains(destinoPropName);
                }

                if (procesar)
                {
                    // se puede mapear
                    if (origenProperties.ContainsKey(destinoPropName))
                    {
                        PropertyInfo piOrigen = origenProperties[destinoPropName];

                        piDestino.SetValue(destino, piOrigen.GetValue(origen, null), null);
                    }
                }
            }
        }

        public static List<TDto> ToDtoList<TDto, TDb>(List<TDb> dbentityList) where TDto : new()
        {
            List<TDto> tDtoList = new List<TDto>();

            TDto tDto = default(TDto);
            foreach (TDb dbEntity in dbentityList)
            {
                tDto = new TDto();
                EntityMapper.Map(dbEntity, tDto);
                tDtoList.Add(tDto);
            }

            return tDtoList;
        }

        public static void Map(Page pageOrigen, object entityDestino)
        {
            Type tdestino = entityDestino.GetType();

            PropertyInfo[] destinoProperties = tdestino.GetProperties();

            bool setValue = false;
            foreach (PropertyInfo piDestino in destinoProperties)
            {
                setValue = false;
                string destinoPropName = piDestino.Name;

                Type piDestinoType = piDestino.PropertyType;

                Control controlOrigen;
                object origenValue = null;
                if (piDestinoType == typeof(Int32))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        origenValue = UIWebHelper.GetIntFromInputText((TextBox)controlOrigen).Value;
                        setValue = true;
                    }
                    else
                    {
                        controlOrigen = FindControlRecursive(pageOrigen, "cbo" + destinoPropName);
                        if (controlOrigen != null)
                        {
                            setValue = true;
                            origenValue = UIWebHelper.GetIntFromInputCbo((DropDownList)controlOrigen).Value;
                        }
                    }
                }
                else if (piDestinoType == typeof(Int64))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = UIWebHelper.GetLongFromInputText((TextBox)controlOrigen).Value;
                    }
                    else
                    {
                        controlOrigen = FindControlRecursive(pageOrigen, "cbo" + destinoPropName);
                        if (controlOrigen != null)
                        {
                            setValue = true;
                            origenValue = UIWebHelper.GetLongFromInputCbo((DropDownList)controlOrigen).Value;
                        }
                    }
                }
                else if (piDestinoType == typeof(decimal))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = UIWebHelper.GetDecimalFromInputText((TextBox)controlOrigen).Value;
                    }
                }
                if (piDestinoType == typeof(Int32?))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = UIWebHelper.GetIntFromInputText((TextBox)controlOrigen);
                    }
                    else
                    {
                        controlOrigen = FindControlRecursive(pageOrigen, "cbo" + destinoPropName);
                        if (controlOrigen != null)
                        {
                            setValue = true;
                            origenValue = UIWebHelper.GetIntFromInputCbo((DropDownList)controlOrigen);
                        }
                    }
                }
                else if (piDestinoType == typeof(Int64?))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = UIWebHelper.GetLongFromInputText((TextBox)controlOrigen);
                    }
                    else
                    {
                        controlOrigen = FindControlRecursive(pageOrigen, "cbo" + destinoPropName);
                        if (controlOrigen != null)
                        {
                            setValue = true;
                            origenValue = UIWebHelper.GetLongFromInputCbo((DropDownList)controlOrigen);
                        }
                    }
                }
                else if (piDestinoType == typeof(decimal?))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = UIWebHelper.GetDecimalFromInputText((TextBox)controlOrigen);
                    }
                }
                else if (piDestinoType == typeof(string))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = ((TextBox)controlOrigen).Text;
                    }
                    else
                    {
                        controlOrigen = FindControlRecursive(pageOrigen, "cbo" + destinoPropName);
                        if (controlOrigen != null)
                        {
                            setValue = true;
                            origenValue = ((DropDownList)controlOrigen).SelectedValue;
                        }
                    }
                }
                else if (piDestinoType == typeof(DateTime))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = UIWebHelper.GetDateTimeFromInputText((TextBox)controlOrigen).Value;
                    }
                }
                else if (piDestinoType == typeof(DateTime?))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = UIWebHelper.GetDateTimeFromInputText((TextBox)controlOrigen);
                    }
                }
                else if (piDestinoType == typeof(bool?))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "chk" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = ((CheckBox)controlOrigen).Checked;
                    }
                }
                else if (piDestinoType == typeof(bool))
                {
                    controlOrigen = FindControlRecursive(pageOrigen, "chk" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        setValue = true;
                        origenValue = ((CheckBox)controlOrigen).Checked;
                    }
                }

                if (setValue)
                {
                    piDestino.SetValue(entityDestino, origenValue, null);
                }
            }
        }

        public static void Map(object entityOrigen, Page pageDestino)
        {
            Type tdestino = entityOrigen.GetType();

            PropertyInfo[] destinoProperties = tdestino.GetProperties();

            foreach (PropertyInfo piDestino in destinoProperties)
            {
                string destinoPropName = piDestino.Name;

                Type piDestinoType = piDestino.PropertyType;

                Control controlOrigen;
                object origenValue = piDestino.GetValue(entityOrigen, null);
                if (piDestinoType == typeof(Int32) || piDestinoType == typeof(Int64) || piDestinoType == typeof(decimal))
                {
                    controlOrigen = FindControlRecursive(pageDestino, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        txt.Text = Convert.ToString(origenValue);
                    }
                    else
                    {
                        controlOrigen = FindControlRecursive(pageDestino, "cbo" + destinoPropName);
                        if (controlOrigen != null)
                        {
                            ((DropDownList)controlOrigen).SelectedValue = Convert.ToString(origenValue);
                        }
                    }
                }
                if (piDestinoType == typeof(Int32?) || piDestinoType == typeof(Int64?) || piDestinoType == typeof(decimal?))
                {
                    controlOrigen = FindControlRecursive(pageDestino, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        if (origenValue == null)
                        {
                            txt.Text = string.Empty;
                        }
                        else
                        {
                            txt.Text = Convert.ToString(origenValue);
                        }
                    }
                    else
                    {
                        controlOrigen = FindControlRecursive(pageDestino, "cbo" + destinoPropName);
                        if (controlOrigen != null)
                        {
                            DropDownList cbo = (DropDownList)controlOrigen;
                            if (origenValue == null)
                            {
                                //cbo.SelectedIndex = -1; // (??)
                                cbo.ClearSelection();
                            }
                            else
                            {
                                cbo.SelectedValue = Convert.ToString(origenValue);
                            }
                        }
                    }
                }
                else if (piDestinoType == typeof(string))
                {
                    controlOrigen = FindControlRecursive(pageDestino, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        txt.Text = Convert.ToString(origenValue);
                    }
                    else
                    {
                        controlOrigen = FindControlRecursive(pageDestino, "cbo" + destinoPropName);
                        if (controlOrigen != null)
                        {
                            DropDownList cbo = (DropDownList)controlOrigen;
                            cbo.SelectedValue = Convert.ToString(origenValue);
                        }
                    }
                }
                else if (piDestinoType == typeof(DateTime))
                {
                    controlOrigen = FindControlRecursive(pageDestino, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        txt.Text = ((DateTime)origenValue).ToString("dd/MM/yyyy");
                    }
                }
                else if (piDestinoType == typeof(DateTime?))
                {
                    controlOrigen = FindControlRecursive(pageDestino, "txt" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        if (origenValue == null)
                        {
                            txt.Text = string.Empty;
                        }
                        else
                        {
                            txt.Text = ((DateTime)origenValue).ToString("dd/MM/yyyy");
                        }
                    }
                }
                else if (piDestinoType == typeof(bool?))
                {
                    controlOrigen = FindControlRecursive(pageDestino, "chk" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        CheckBox txt = (CheckBox)controlOrigen;
                        if (origenValue == null)
                        {
                            txt.Checked = false;
                        }
                        else
                        {
                            txt.Checked = ((bool?)origenValue).Value;
                        }
                    }
                }
                else if (piDestinoType == typeof(bool))
                {
                    controlOrigen = FindControlRecursive(pageDestino, "chk" + destinoPropName);
                    if (controlOrigen != null)
                    {
                        CheckBox txt = (CheckBox)controlOrigen;
                        if (origenValue == null)
                        {
                            txt.Checked = false;
                        }
                        else
                        {
                            txt.Checked = ((bool)origenValue);
                        }
                    }
                }
            }
        }

        public static object GetValueFromWebControl(WebControl ctrl)
        {
            object value = null;

            WebControl current = null;

            current = ctrl as TextBox;
            if (current != null)
            {
                TextBox txt = ctrl as TextBox;
                value = txt.Text;
            }
            else
            {
                current = ctrl as DropDownList;
                if (current != null)
                {
                    DropDownList cbo = ctrl as DropDownList;
                    if (cbo.SelectedIndex >= 0)
                    {
                        value = cbo.SelectedValue;
                    }
                }
                else
                {
                    current = ctrl as CheckBox;
                    if (current != null)
                    {
                        CheckBox chk = ctrl as CheckBox;
                        value = chk.Checked;
                    }
                }
            }

            return value;
        }

        public static void SetValueToWebCtrl(WebControl ctrl, object value)
        {
            WebControl controlOrigen;
            if (value != null)
            {
                Type piDestinoType = value.GetType();
                if (piDestinoType == typeof(Int32) || piDestinoType == typeof(Int64) || piDestinoType == typeof(decimal))
                {
                    controlOrigen = ctrl as TextBox;
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        txt.Text = Convert.ToString(value);
                    }
                    else
                    {
                        controlOrigen = ctrl as DropDownList;
                        if (controlOrigen != null)
                        {
                            ((DropDownList)controlOrigen).SelectedValue = Convert.ToString(value);
                        }
                    }
                }
                if (piDestinoType == typeof(Int32?) || piDestinoType == typeof(Int64?) || piDestinoType == typeof(decimal?))
                {
                    controlOrigen = ctrl as TextBox;
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        if (value == null)
                        {
                            txt.Text = string.Empty;
                        }
                        else
                        {
                            txt.Text = Convert.ToString(value);
                        }
                    }
                    else
                    {
                        controlOrigen = ctrl as DropDownList;
                        if (controlOrigen != null)
                        {
                            DropDownList cbo = (DropDownList)controlOrigen;
                            if (value == null)
                            {
                                //cbo.SelectedIndex = -1; // (??)
                                cbo.ClearSelection();
                            }
                            else
                            {
                                cbo.SelectedValue = Convert.ToString(value);
                            }
                        }
                    }
                }
                else if (piDestinoType == typeof(string))
                {
                    controlOrigen = ctrl as TextBox;
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        txt.Text = Convert.ToString(value);
                    }
                    else
                    {
                        controlOrigen = ctrl as DropDownList;
                        if (controlOrigen != null)
                        {
                            DropDownList cbo = (DropDownList)controlOrigen;
                            cbo.SelectedValue = Convert.ToString(value);
                        }
                    }
                }
                else if (piDestinoType == typeof(DateTime))
                {
                    controlOrigen = ctrl as TextBox;
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        txt.Text = ((DateTime)value).ToString("dd/MM/yyyy");
                    }
                }
                else if (piDestinoType == typeof(DateTime?))
                {
                    controlOrigen = ctrl as TextBox;
                    if (controlOrigen != null)
                    {
                        TextBox txt = (TextBox)controlOrigen;
                        if (value == null)
                        {
                            txt.Text = string.Empty;
                        }
                        else
                        {
                            txt.Text = ((DateTime)value).ToString("dd/MM/yyyy");
                        }
                    }
                }
                else if (piDestinoType == typeof(bool?))
                {
                    controlOrigen = ctrl as CheckBox;
                    if (controlOrigen != null)
                    {
                        CheckBox txt = (CheckBox)controlOrigen;
                        if (value == null)
                        {
                            txt.Checked = false;
                        }
                        else
                        {
                            txt.Checked = ((bool?)value).Value;
                        }
                    }
                }
                else if (piDestinoType == typeof(bool))
                {
                    controlOrigen = ctrl as CheckBox;
                    if (controlOrigen != null)
                    {
                        CheckBox txt = (CheckBox)controlOrigen;
                        if (value == null)
                        {
                            txt.Checked = false;
                        }
                        else
                        {
                            txt.Checked = ((bool)value);
                        }
                    }
                }
            }
        }

        public static Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn =
                    FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null) return controlToReturn;
            }
            return null;
        }
    }

}
