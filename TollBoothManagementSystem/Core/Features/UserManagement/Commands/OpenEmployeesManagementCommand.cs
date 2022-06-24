using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Commands
{
    public class OpenEmployeesManagementCommand : CommandBase
    {
        public OpenEmployeesManagementCommand() { 
        
        }

        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("EmployeesManagement");
        }
    }
}
