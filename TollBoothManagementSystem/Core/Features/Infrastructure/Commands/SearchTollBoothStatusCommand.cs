using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class SearchTollBoothStatusCommand : CommandBase
    {
        TollBoothStatusViewModel _viewModel;
        public SearchTollBoothStatusCommand(TollBoothStatusViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.SearchTollBooth();
        }
    }
}
