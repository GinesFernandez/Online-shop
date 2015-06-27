using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UniversalApp.Helpers
{
    public class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(email))
                    return (true);
            }
            return (false);
        }

        public static bool IsValidPercentage(string perc) //max 3 decimals
        {
            if (!String.IsNullOrEmpty(perc))
            {
                string strRegex = @"^(100(?:\.0{1,3})?|0*?\.\d{1,3}|\d{1,3}(?:\.\d{1,3})?)$";

                string coma = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                strRegex = strRegex.Replace(".", coma);

                Regex re = new Regex(strRegex);
                if (re.IsMatch(perc))
                    return (true);
            }
            return (false);
        }

        public static bool IsValidNIF(string nif)
        {
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            int nifNum;
            bool valido = true;

            if (nif == null)
                return false;

            if (!System.Text.RegularExpressions.Regex.IsMatch(nif, @"^\d{8}[" + letras + "]$"))
                valido = false;
            else
            {
                nifNum = int.Parse(nif.Substring(0, nif.Length - 1));
                if (nif[8] != letras[nifNum % 23])
                    valido = false;
            }
            return valido;
        }
    }
}
