using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class ElectronicTollCollectionService : IElectronicTollCollectionService
    {
        private readonly IElectronicTollCollectionRepository _electronicTollCollectionRepository;

        public ElectronicTollCollectionService(IElectronicTollCollectionRepository electronicTollCollectionRepository)
        {
            _electronicTollCollectionRepository = electronicTollCollectionRepository;
        }

        #region CRUD methods

        public IEnumerable<ElectronicTollCollection> ReadAll()
        {
            return _electronicTollCollectionRepository.ReadAll();
        }

        public ElectronicTollCollection Read(Guid electronicTollCollectionId)
        {
            return _electronicTollCollectionRepository.Read(electronicTollCollectionId);
        }

        public ElectronicTollCollection Create(ElectronicTollCollection newElectronicTollCollection)
        {
            return _electronicTollCollectionRepository.Create(newElectronicTollCollection);
        }

        public ElectronicTollCollection Update(ElectronicTollCollection electronicTollCollectionToUpdate)
        {
            return _electronicTollCollectionRepository.Update(electronicTollCollectionToUpdate);
        }

        public ElectronicTollCollection Delete(Guid electronicTollCollectionId)
        {
            return _electronicTollCollectionRepository.Delete(electronicTollCollectionId);
        }

        #endregion
    }
}
