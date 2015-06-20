using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace UniversalApp.Helpers
{
    public class StorageHelper // TODO: IStorageHelper
    {
        public static async void Save()
        {
            var roamingFolder = ApplicationData.Current.RoamingFolder;
            var file = await roamingFolder.CreateFileAsync("file.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, "Ejemplo archivo en RoamingFolder");
        }

        /// <summary>
        /// Method called when the RoamingFolder is changed from another app (universal apps)
        /// </summary>
        /// <param name="appData"></param>
        /// <param name="o"></param>
        //public static async void DataChangedHandler(ApplicationData appData, object o)
        //{
        //TODO:
        //}
    }
}
