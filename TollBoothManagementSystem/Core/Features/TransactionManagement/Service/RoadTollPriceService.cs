using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class RoadTollPriceService : IRoadTollPriceService
    {
        private readonly IRoadTollPriceRepository _roadTollPriceRepository;
        private readonly IRoadTollService _roadTollService;
        private readonly IPriceListService _priceListService;
        private readonly ICurrencyService _currencyService;

        public RoadTollPriceService(IRoadTollPriceRepository roadTollPriceRepository, IRoadTollService roadTollService,
             ICurrencyService currencyService)
        {
            _roadTollPriceRepository = roadTollPriceRepository;
            _roadTollService = roadTollService;
            _currencyService = currencyService;
        }

        #region CRUD methods

        public IEnumerable<RoadTollPrice> ReadAll()
        {
            return _roadTollPriceRepository.ReadAll();
        }

        public RoadTollPrice Read(Guid roadTollPriceId)
        {
            return _roadTollPriceRepository.Read(roadTollPriceId);
        }

        public RoadTollPrice Create(RoadTollPrice newRoadTollPrice)
        {
            return _roadTollPriceRepository.Create(newRoadTollPrice);
        }

        public RoadTollPrice Update(RoadTollPrice roadTollPriceToUpdate)
        {
            return _roadTollPriceRepository.Update(roadTollPriceToUpdate);
        }

        public RoadTollPrice Delete(Guid roadTollPriceId)
        {
            return _roadTollPriceRepository.Delete(roadTollPriceId);
        }

        #endregion

        public double CalculatePrice(PriceList pricelist, VehicleType vehicleType, Currency currency, TollStation enterStation, TollStation exitStation)
        {
            RoadToll tollExit;
            RoadToll tollEnter;
            try
            {
                tollExit = _roadTollService.GetRoadToll(vehicleType, currency, exitStation);
                tollEnter = _roadTollService.GetRoadToll(vehicleType, currency, enterStation);
            }
            catch
            {
                throw new Exception("Cannot find road toll for given parameters");
            }
            double priceEnter = _roadTollPriceRepository.ReadAll().First(e => e.PriceList.Id == pricelist.Id && e.RoadToll.Id == tollEnter.Id).Price;
            double priceExit = _roadTollPriceRepository.ReadAll().First(e => e.PriceList.Id == pricelist.Id && e.RoadToll.Id == tollExit.Id).Price;
            return Math.Abs(priceExit - priceEnter);
        }

        public void GeneratePrices(PriceList priceList, TollStation tollStation, int basePrice)
        {
            foreach (var currency in _currencyService.ReadAll())
            {
                double qoef = 1;
                var convertedBasePrice = basePrice;

                if (currency.Code == "EUR")
                    convertedBasePrice = basePrice / 117;

                foreach (VehicleType vehicleType in Enum.GetValues(typeof(VehicleType)))
                {
                    RoadToll newRoadToll = new RoadToll()
                    {
                        TollStation = tollStation,
                        VehicleType = vehicleType,
                        Currency = currency
                    };
                    _roadTollService.Create(newRoadToll);

                    var price = qoef * convertedBasePrice;
                    RoadTollPrice newRoadTollPrice = new RoadTollPrice()
                    {
                        PriceList = priceList,
                        RoadToll = newRoadToll,
                        Price = (int) price
                    };
                    Create(newRoadTollPrice);

                    qoef += 1;
                }
            }
        }
    }
}
