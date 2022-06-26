using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class OpenTollBoothStatusesCommand : CommandBase
    {
        public OpenTollBoothStatusesCommand()
        {

        }

        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("TollBoothStatuses");
        }
    }
}
