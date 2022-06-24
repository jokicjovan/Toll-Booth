using System;

namespace TollBoothManagementSystem.GUI.Utility.Dialog
{
    public interface IDialogService
    {
        public void ShowDialog<T>(DialogViewModelBase<T> dialogViewModel, Action<bool?> callback);
    }
}