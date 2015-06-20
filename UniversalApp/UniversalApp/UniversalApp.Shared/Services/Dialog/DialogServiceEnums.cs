using System;

namespace UniversalApp.Services.Dialogs
{
    [Flags]
    public enum MessageBoxButton
    {
        /// <summary>
        /// Displays only the OK button.
        /// </summary>
        OK = 1,

        /// <summary>
        /// Displays only the Cancel button.
        /// </summary>
        Cancel = 2,

        /// <summary>
        /// Displays both the OK and Cancel buttons.
        /// </summary>
        OKCancel = OK | Cancel,

        /// <summary>
        /// Displays only the Yes button.
        /// </summary>
        Yes = 4,

        /// <summary>
        /// Displays only the No button.
        /// </summary>
        No = 8,

        /// <summary>
        /// Displays both the Yes and Cancel buttons.
        /// </summary>
        YesNo = Yes | No,

        /// <summary>
        /// Displays both the Yes, No and Cancel buttons.
        /// </summary>
        //YesNoCancel = Yes | No | Cancel (NO SE PUEDE)
    }

    /// <summary>
    /// Represents a user's response to a message box.
    /// </summary>
    public enum MessageBoxResult
    {
        None = 0,
        OK = 1,
        Cancel = 2,
        Yes = 6,
        No = 7,
    }
}
