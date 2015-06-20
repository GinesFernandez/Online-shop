using System.Threading.Tasks;

namespace UniversalApp.Services.Dialogs
{
    public interface IDialogService
    {
        Task ShowAsync(string message, string title = null);

        Task<MessageBoxResult> ShowAsync(MessageBoxButton buttons, string message, string title = null);
    }
}
