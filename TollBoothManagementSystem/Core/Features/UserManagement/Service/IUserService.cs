using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Service
{
    public interface IUserService : ICrudRepository<User>
    {
        public User Authenticate(string email, string password);

        public bool IsEmailUsed(string email);
    }
}