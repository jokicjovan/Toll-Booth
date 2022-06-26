using System.ComponentModel;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class ReportGateFaultCommand : CommandBase
    {
        private FaultReportViewModel _viewModel;
        public ReportGateFaultCommand(FaultReportViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedTollBooth))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !(_viewModel.SelectedTollBooth == null) && !(_viewModel.SelectedTollBooth.IsTrafficLightFunctional == false) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.SelectedTollBooth.IsTollGateFunctional = false;
            _viewModel.TollBoothService.Update(_viewModel.SelectedTollBooth);
            _viewModel.SelectedTollBooth = null;
            _viewModel.Search();
            //MessageBox.Show("TollBooth traffic light fixed successfully");
        }
    }
}
