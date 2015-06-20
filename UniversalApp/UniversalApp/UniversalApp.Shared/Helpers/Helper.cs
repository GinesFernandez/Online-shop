using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace UniversalApp.Helpers
{
    public class Helper
    {
        /// <summary>
        /// Enciende la barra de progreso y deshabilita los controles pasados en la lista (IsEnabled = false)
        /// </summary>
        /// <param name="progressBar">ProgressBar</param>
        /// <param name="controles">List de Control</param>
        public static void ProgressON(ProgressBar progressBar, List<Control> controles = null)
        {
            progressBar.IsIndeterminate = true;

            if (controles != null)
            {
                foreach (Control c in controles)
                {
                    c.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Apaga la barra de progreso y habilita los controles pasados en la lista (IsEnabled = true)
        /// </summary>
        /// <param name="progressBar">ProgressBar</param>
        /// <param name="controles">List de Control</param>
        public static void ProgressOFF(ProgressBar progressBar, List<Control> controles = null)
        {
            progressBar.IsIndeterminate = false;
            //progressText = string.Empty;

            if (controles != null)
            {
                foreach (Control c in controles)
                {
                    c.IsEnabled = true;
                }
            }
        }

        public static string Desnaturalizador(string cadena)
        {
            if (cadena != null)
            {
                string temporal = "";
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i] == 'á' || cadena[i] == 'Á' || cadena[i] == 'à' || cadena[i] == 'À'
                        || cadena[i] == 'ä' || cadena[i] == 'Ä' || cadena[i] == 'â' || cadena[i] == 'Â')
                        temporal += "A";
                    else if (cadena[i] == 'é' || cadena[i] == 'É' || cadena[i] == 'è' || cadena[i] == 'È'
                        || cadena[i] == 'ë' || cadena[i] == 'Ë' || cadena[i] == 'ê' || cadena[i] == 'Ê')
                        temporal += "E";
                    else if (cadena[i] == 'í' || cadena[i] == 'Í' || cadena[i] == 'ì' || cadena[i] == 'Ì'
                        || cadena[i] == 'ï' || cadena[i] == 'Ï' || cadena[i] == 'î' || cadena[i] == 'Î')
                        temporal += "I";
                    else if (cadena[i] == 'ó' || cadena[i] == 'Ó' || cadena[i] == 'ò' || cadena[i] == 'Ò'
                        || cadena[i] == 'ö' || cadena[i] == 'Ö' || cadena[i] == 'ô' || cadena[i] == 'Ô')
                        temporal += "O";
                    else if (cadena[i] == 'ú' || cadena[i] == 'Ú' || cadena[i] == 'ù' || cadena[i] == 'Ù'
                        || cadena[i] == 'ü' || cadena[i] == 'Ü' || cadena[i] == 'û' || cadena[i] == 'Û')
                        temporal += "U";
                    else temporal += cadena[i].ToString().ToUpper();
                }
                return temporal;
            }
            else
                return "";
        }
    }
}
