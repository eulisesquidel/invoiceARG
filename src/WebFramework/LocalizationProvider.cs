using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml.Linq;
using System.Web;

namespace Web.Framework.Translate
{
    public class LocalizationProvider
    {
        public const string CookieLangKey = "cookieLangKey";

        private static LocalizationProvider _instance;

        private string translationFilePath = string.Empty;

        private void SetSessionLanguaje(string codigoLenguaje)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["codLanguajeByUser"] = codigoLenguaje;               
            }
        }

        public string GetCodigoLenguajeBySession()
        {
            string codigoLenguaje = ConfigurationManager.AppSettings["LenguajePorDefecto"];

            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                string tmpCodigoLenguaje = Convert.ToString(HttpContext.Current.Session["codLanguajeByUser"]);
                if (!String.IsNullOrEmpty(tmpCodigoLenguaje))
                {
                    codigoLenguaje = tmpCodigoLenguaje;
                }
            }

            return codigoLenguaje;
        }

        private Dictionary<string,Dictionary<string, string>> _innerDictionaryByLang = new  Dictionary<string,Dictionary<string, string>>();      

        public static void InitalizeInstance(string codigoLenguaje)
        {
            _instance = new LocalizationProvider();

            // para un usuario inicializo el lenguaje
            _instance.SetSessionLanguaje(codigoLenguaje);
            
        }

        public Dictionary<string, string> GetTemrs(string codigoLenguaje)
        {
            Dictionary<string, string> terms = new Dictionary<string, string>();
            if (_instance._innerDictionaryByLang.ContainsKey(codigoLenguaje))
            {
                terms = _instance._innerDictionaryByLang[codigoLenguaje];
            }

            return terms;
        }

        public void SetTermsForLanguaje(string codigoLenguaje, Dictionary<string, string> terms)
        {
            if (!_instance._innerDictionaryByLang.ContainsKey(codigoLenguaje))
            {
                _instance._innerDictionaryByLang.Add(codigoLenguaje, null);
            }

            _instance._innerDictionaryByLang[_instance.GetCodigoLenguajeBySession()] = terms;
        }
        
        public string this[string key]
        {
            get
            {
                string returnValue = string.Empty;

                string innerKey = _instance.GetCodigoLenguajeBySession();
                if (_innerDictionaryByLang.ContainsKey(innerKey))
                {
                    if (_innerDictionaryByLang[_instance.GetCodigoLenguajeBySession()].ContainsKey(key))
                    {
                        returnValue = _innerDictionaryByLang[_instance.GetCodigoLenguajeBySession()][key];
                    }
                }

                return returnValue;
            }
        }

        public static LocalizationProvider Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
