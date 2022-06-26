using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class SearchTollStationCommand : CommandBase
    {
        TollStationsViewModel _viewModel;
        public SearchTollStationCommand(TollStationsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.SearchTollStation();
        }
    }
}
