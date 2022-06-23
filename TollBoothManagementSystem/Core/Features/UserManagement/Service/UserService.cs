using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region CRUD methods

        public IEnumerable<User> ReadAll()
        {
            return _userRepository.ReadAll();
        }

        public User Read(Guid userId)
        {
            return _userRepository.Read(userId);
        }

        public User Create(User newUser)
        {
            return _userRepository.Create(newUser);
        }

        public User Update(User userToUpdate)
        {
            return _userRepository.Update(userToUpdate);
        }

        public User Delete(Guid userToDelete)
        {
            return _userRepository.Delete(userToDelete);
        }

        #endregion

        public User Authenticate(string email, string password)
        {
            return _userRepository.Authenticate(email, password);
        }


        public bool IsEmailUsed(string email)
        {
            return _userRepository.IsEmailUsed(email);
        }
    }

}
