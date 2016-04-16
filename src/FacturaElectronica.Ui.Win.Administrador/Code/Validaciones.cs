using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Ui.Win.Administrador.Code
{
    public static class Validaciones
    {
        public static bool IsNumeber(string inputStr)
        {
            bool isNumeric = true;
            for (int i = 0; i < inputStr.Length && isNumeric; i++)
            {
                isNumeric = char.IsNumber(inputStr[i]);
            }

            return isNumeric;
        }
    }
}
