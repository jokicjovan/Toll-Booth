using System.ComponentModel;
using TollBooth.Core.Utility.Commands;
using TollBooth.Core.Utility.EventManipulation;

namespace TollBooth.Core.Features.ApplicationAccess.Commands
{
    public class LogOutCommand : CommandBase
    {
        public LogOutCommand()
        {
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChange();
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("BackToLogin");
        }
    }
}
