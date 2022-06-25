using System;

namespace TollBoothManagementSystem.GUI.Utility.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowDialog<T>(DialogViewModelBase<T> dialogViewModel, Action<bool?> callback)
        {
            var dialog = new DialogWindow()
            {
                DataContext = dialogViewModel
            };

            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult);
                dialog.Closed -= closeEventHandler;
            };
            dialog.Closed += closeEventHandler;

            dialog.ShowDialog();
        }
    }
}
