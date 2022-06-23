using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class RoadTollPaymentService : IRoadTollPaymentService
    {
        private readonly IRoadTollPaymentRepository _roadTollPaymentRepository;

        public RoadTollPaymentService(IRoadTollPaymentRepository roadTollPaymentRepository)
        {
            _roadTollPaymentRepository = roadTollPaymentRepository;
        }

        #region CRUD methods

        public IEnumerable<RoadTollPayment> ReadAll()
        {
            return _roadTollPaymentRepository.ReadAll();
        }

        public RoadTollPayment Read(Guid roadTollPaymentId)
        {
            return _roadTollPaymentRepository.Read(roadTollPaymentId);
        }

        public RoadTollPayment Create(RoadTollPayment newRoadTollPayment)
        {
            return _roadTollPaymentRepository.Create(newRoadTollPayment);
        }

        public RoadTollPayment Update(RoadTollPayment roadTollPaymentToUpdate)
        {
            return _roadTollPaymentRepository.Update(roadTollPaymentToUpdate);
        }

        public RoadTollPayment Delete(Guid roadTollPaymentId)
        {
            return _roadTollPaymentRepository.Delete(roadTollPaymentId);
        }

        #endregion
    }
}
