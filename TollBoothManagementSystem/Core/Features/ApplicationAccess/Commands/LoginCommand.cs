using System.ComponentModel;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Navigation;

namespace TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel? _viewModel;

        public LoginCommand(LoginViewModel lwm)
        {
            _viewModel = lwm;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Email) || e.PropertyName == nameof(_viewModel.Password))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Email) && !string.IsNullOrEmpty(_viewModel.Password) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            
        }
    }
}
