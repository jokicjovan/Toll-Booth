using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.General.Repository;

namespace TollBoothManagementSystem.Core.Features.General.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        #region CRUD methods

        public IEnumerable<Currency> ReadAll()
        {
            return _currencyRepository.ReadAll();
        }

        public Currency Read(Guid currencyId)
        {
            return _currencyRepository.Read(currencyId);
        }

        public Currency Create(Currency newCurrency)
        {
            return _currencyRepository.Create(newCurrency);
        }

        public Currency Update(Currency currencyToUpdate)
        {
            return _currencyRepository.Update(currencyToUpdate);
        }

        public Currency Delete(Guid currencyId)
        {
            return _currencyRepository.Delete(currencyId);
        }

        #endregion

        public Currency? GetCurrencyByCode(string code)
        {
            return _currencyRepository.ReadAll().FirstOrDefault(e => e.Code.ToLower() == code.ToLower());
        }
    }
}
