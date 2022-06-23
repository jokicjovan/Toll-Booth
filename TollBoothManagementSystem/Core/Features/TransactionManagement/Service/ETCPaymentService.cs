using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class ETCPaymentService : IETCPaymentService
    {
        private readonly IETCPaymentRepository _etcPaymentRepository;

        public ETCPaymentService(IETCPaymentRepository etcPaymentRepository)
        {
            _etcPaymentRepository = etcPaymentRepository;
        }

        #region CRUD methods

        public IEnumerable<ETCPayment> ReadAll()
        {
            return _etcPaymentRepository.ReadAll();
        }

        public ETCPayment Read(Guid etcPaymentId)
        {
            return _etcPaymentRepository.Read(etcPaymentId);
        }

        public ETCPayment Create(ETCPayment newETCPayment)
        {
            return _etcPaymentRepository.Create(newETCPayment);
        }

        public ETCPayment Update(ETCPayment etcPaymentToUpdate)
        {
            return _etcPaymentRepository.Update(etcPaymentToUpdate);
        }

        public ETCPayment Delete(Guid etcPaymentId)
        {
            return _etcPaymentRepository.Delete(etcPaymentId);
        }

        #endregion
    }
}
