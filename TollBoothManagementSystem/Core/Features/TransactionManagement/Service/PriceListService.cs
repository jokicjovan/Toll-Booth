using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class PriceListService : IPriceListService
    {
        private readonly IPriceListRepository _priceListRepository;

        private readonly ISectionService _sectionService;
        public PriceListService(IPriceListRepository priceListRepository, ISectionService sectionService)
        {
            _priceListRepository = priceListRepository;
            _sectionService = sectionService;
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

        private PriceList FindActivePricelist(Section section)
        {
            return _priceListRepository.ReadAll()
                                       .First(e => e.Section.Id == section.Id && DateTime.Now >= e.ActivationDate && DateTime.Now <= e.ExpirationDate);
        }

        public PriceList GetActivePricelist(Section section)
        {
            var activePriceList = FindActivePricelist(section);

            if (activePriceList == null)
            {
                activePriceList = new PriceList()
                {
                    ActivationDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddYears(1),
                    Section = section
                };

                Create(activePriceList);
            }

            return activePriceList;
        }
        public void GeneratePrices(Section section, int basePrice)
        {
            var priceList = GetActivePricelist(section);



        }
    }
}
