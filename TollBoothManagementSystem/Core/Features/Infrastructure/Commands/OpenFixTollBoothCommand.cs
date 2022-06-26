using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class OpenFixTollBoothCommand : CommandBase
    {
        public OpenFixTollBoothCommand()
        {

        }

        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("FixTollBooth");
        }
    }
}
