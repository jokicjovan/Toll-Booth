using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;
using System.Linq;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class PriceListService : IPriceListService
    {
        private readonly IPriceListRepository _priceListRepository;

        public PriceListService(IPriceListRepository priceListRepository)
        {
            _priceListRepository = priceListRepository;
        }

        #region CRUD methods

        public IEnumerable<PriceList> ReadAll()
        {
            return _priceListRepository.ReadAll();
        }

        public PriceList Read(Guid priceListId)
        {
            return _priceListRepository.Read(priceListId);
        }

        public PriceList Create(PriceList newPriceList)
        {
            return _priceListRepository.Create(newPriceList);
        }

        public PriceList Update(PriceList priceListToUpdate)
        {
            return _priceListRepository.Update(priceListToUpdate);
        }

        public PriceList Delete(Guid prcieListId)
        {
            return _priceListRepository.Delete(prcieListId);
        }

        #endregion

        public PriceList GetActivePricelist(Section section)
        {
            return _priceListRepository.ReadAll().First(e => e.Section.Id == section.Id && DateTime.Now >= e.ActivationDate && DateTime.Now <= e.ExpirationDate);
        }
    }
}
