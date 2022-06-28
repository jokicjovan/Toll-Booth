using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.ManagerCMD
{
    public class OpenStationIncomeReportCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("StationIncomeReport");
        }
    }
}
