using System;
using System.Collections.Generic;
using System.Text;
using UniversalApp.Model;

namespace UniversalApp
{
    public class Globals
    {
        internal static bool ResourcesLoaded;

        public static Users CurrentUser { get; set; }

        private static float _taxPercentage = 18;
        public static float TaxPercentage
        {
            get { return Globals._taxPercentage; }
            set { Globals._taxPercentage = value; }
        }

        private static string _currency = "€";
        public static string Currency
        {
            get { return Globals._currency; }
            set { Globals._currency = value; }
        }
    }
}
