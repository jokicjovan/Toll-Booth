using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.TransactionManagement;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.ReferentCMD
{
    public class ConfirmPaymentCommand : CommandBase
    {
        private readonly RoadTollPaymentViewModel _viewModel;

        public ConfirmPaymentCommand(RoadTollPaymentViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {

        }
    }
}
