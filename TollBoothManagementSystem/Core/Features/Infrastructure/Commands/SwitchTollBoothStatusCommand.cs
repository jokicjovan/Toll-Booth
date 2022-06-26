using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Navigation;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class SwitchTollBoothStatusCommand : CommandBase
    {
        private ReferentHomeViewModel _viewModel;

        public SwitchTollBoothStatusCommand(ReferentHomeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.IsOpen = !_viewModel.IsOpen;
        }
    }
}
