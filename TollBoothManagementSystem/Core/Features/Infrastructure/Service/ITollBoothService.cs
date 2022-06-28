using System;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Utility;


namespace TollBoothManagementSystem.Core.Features.Infrastructure.Service
{
    public interface ITollBoothService : ICrudRepository<TollBooth>
    {
        public double GetIncome(TollBooth tollBooth, DateTime startDate, DateTime endDate, Currency currency);
    }
}
