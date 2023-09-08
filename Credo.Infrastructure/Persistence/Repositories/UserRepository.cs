using Credo.Application.Common.Interfaces.Persistence;
using Credo.Domain.Users;

namespace Credo.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CredoDbContext _dbContext;

        public UserRepository(CredoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            _dbContext.Add(user);

            //_dbContext.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            //return _dataDbContext.SingleOrDefault(u => u.Email == email);
            return null;
        }
    }
}
