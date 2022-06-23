using System.Collections.Generic;
using System;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Service
{
    public class ShiftService :IShiftService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        #region CRUD methods

        public IEnumerable<Shift> ReadAll()
        {
            return _shiftRepository.ReadAll();
        }

        public Shift Read(Guid shiftId)
        {
            return _shiftRepository.Read(shiftId);
        }

        public Shift Create(Shift newShift)
        {
            return _shiftRepository.Create(newShift);
        }

        public Shift Update(Shift shiftToUpdate)
        {
            return _shiftRepository.Update(shiftToUpdate);
        }

        public Shift Delete(Guid shiftToDelete)
        {
            return _shiftRepository.Delete(shiftToDelete);
        }

        #endregion
    }
}
