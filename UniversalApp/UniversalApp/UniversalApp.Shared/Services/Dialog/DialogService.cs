using UniversalApp.Strings;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Popups;

namespace UniversalApp.Services.Dialogs
{
    public class DialogService : IDialogService
    {
        /// <summary>
        /// Mensaje en pantalla informativo asíncrono
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task ShowAsync(string message, string title = null)
        {
            var dialog = String.IsNullOrEmpty(title) ? new MessageDialog(message) : new MessageDialog(message, title);
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Mensaje en pantalla configurable asíncrono con respuesta
        /// </summary>
        /// <param name="button">MessageBoxButton</param>
        /// <param name="message">string</param>
        /// <param name="title">string null</param>
        /// <returns></returns>
        public async Task<MessageBoxResult> ShowAsync(MessageBoxButton button, string message, string title = null)
        {
            var dialog = String.IsNullOrEmpty(title) ? new MessageDialog(message) : new MessageDialog(message, title);
            MessageBoxResult result = MessageBoxResult.None;

            if (button.HasFlag(MessageBoxButton.OK))
            {
                dialog.Commands.Add(new UICommand(Cadenas.OK,
                    new UICommandInvokedHandler((cmd) => result = MessageBoxResult.OK)));
            }
            if (button.HasFlag(MessageBoxButton.Yes))
            {
                dialog.Commands.Add(new UICommand(Cadenas.Yes,
                    new UICommandInvokedHandler((cmd) => result = MessageBoxResult.Yes)));
            }
            if (button.HasFlag(MessageBoxButton.No))
            {
                dialog.Commands.Add(new UICommand(Cadenas.No,
                    new UICommandInvokedHandler((cmd) => result = MessageBoxResult.No)));
            }
            if (button.HasFlag(MessageBoxButton.Cancel))
            {
                dialog.Commands.Add(new UICommand(Cadenas.Cancel,
                    new UICommandInvokedHandler((cmd) => result = MessageBoxResult.Cancel)));
                dialog.CancelCommandIndex = (uint)dialog.Commands.Count - 1;
            }

            var op = await dialog.ShowAsync();
            return result;
        }
    }
}
