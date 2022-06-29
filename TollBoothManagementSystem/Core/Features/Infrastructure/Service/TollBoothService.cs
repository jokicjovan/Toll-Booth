using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Repository;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Service
{
    public class TollBoothService : ITollBoothService
    {
        private readonly ITollBoothRepository _tollBoothRepository;
        private readonly IRoadTollPaymentService _roadTollPaymentService;

        public TollBoothService(ITollBoothRepository tollBoothRepository, IRoadTollPaymentService roadTollPaymentService)
        {
            _tollBoothRepository = tollBoothRepository;
            _roadTollPaymentService = roadTollPaymentService;
        }

        public double GetIncome(TollBooth tollBooth, DateTime startDate, DateTime endDate, Currency currency)
        {
            IEnumerable<Payment> payments = _roadTollPaymentService.GetPaymentsForBooth(tollBooth)
                .Where(e => e.ExitTime.Date >= startDate.Date)
                .Where(e => e.ExitTime.Date <= endDate.Date)
                .Where(e => e.Currency.Id == currency.Id);
            return payments.Sum(e => e.Price);
        }

        #region CRUD
        public TollBooth Create(TollBooth entity)
        {
            return _tollBoothRepository.Create(entity);
        }

        public TollBooth Delete(Guid id)
        {
            return _tollBoothRepository.Delete(id);
        }

        public TollBooth Read(Guid id)
        {
            return _tollBoothRepository.Read(id);
        }

        public IEnumerable<TollBooth> ReadAll()
        {
            return _tollBoothRepository.ReadAll();
        }

        public TollBooth Update(TollBooth entity)
        {
            return _tollBoothRepository.Update(entity);
        }
        #endregion
    }
}
