using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.General.Service
{
    public interface ICurrencyService : ICrudRepository<Currency>
    {
        Currency? GetCurrencyByCode(string code);
    }
}