using Credo.Domain.Users;

namespace Credo.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(Guid Id);
        Task<User?> GetUserByPersonalNumber(string PersonalNumber);
        Task AddUser(User user);

    }
}
