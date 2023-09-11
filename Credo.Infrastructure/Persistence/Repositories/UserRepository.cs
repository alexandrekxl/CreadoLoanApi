using Credo.Application.Common.Interfaces.Persistence;
using Credo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Credo.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CredoDbContext _dbContext;

        public UserRepository(CredoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<User?> GetUserById(Guid Id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id.Equals(Id));
        }

        public async Task<User?> GetUserByPersonalNumber(string personalNUmber)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.PersonalNumber == personalNUmber);
        }
            
    }
}
