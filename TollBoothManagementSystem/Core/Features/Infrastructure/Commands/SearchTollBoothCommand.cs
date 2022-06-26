using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class SearchTollBoothCommand : CommandBase
    {
        TollBoothsViewModel _viewModel;
        public SearchTollBoothCommand(TollBoothsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.SearchTollBooth();
        }
    }
}
