using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.AdministratorCMD
{
    public class PriceListOverviewCommand : CommandBase
    {
        public PriceListOverviewCommand()
        {

        }

        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("PriceListOverview");
        }
    }
}
