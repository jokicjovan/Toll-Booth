using System.Linq;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Repository
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {

        }

        public User Authenticate(string email, string password)
        {
            return _entities.FirstOrDefault(u => u.EmailAddress == email && u.Password == password);
        }

        public bool IsEmailUsed(string email)
        {
            return _context.Users.Any(u => u.EmailAddress == email);
        }
    }
}
