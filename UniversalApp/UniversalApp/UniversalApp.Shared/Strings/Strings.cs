using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.Resources.Core;

namespace UniversalApp.Strings
{
    public static class Cadenas
    {
        #region Dialogs
        public static readonly string Yes = ResourceManager.Current.MainResourceMap.GetValue("Resources/Yes", ResourceContext.GetForCurrentView()).ValueAsString;
        public static readonly string No = ResourceManager.Current.MainResourceMap.GetValue("Resources/No", ResourceContext.GetForCurrentView()).ValueAsString;
        public static readonly string OK = ResourceManager.Current.MainResourceMap.GetValue("Resources/OK", ResourceContext.GetForCurrentView()).ValueAsString;
        public static readonly string Cancel = ResourceManager.Current.MainResourceMap.GetValue("Resources/Cancel", ResourceContext.GetForCurrentView()).ValueAsString;
        #endregion
    }
}
