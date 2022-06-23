using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Repository
{
    public interface IUserRepository : ICrudRepository<User>
    {
        User Authenticate(string username, string password);

        bool IsEmailUsed(string email);
    }
}
