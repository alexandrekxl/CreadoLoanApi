using Credo.Domain.Common.Models;
using Credo.Domain.Users;

namespace Credo.Domain.UsersAggregate.Events
{
    public record UserCreated(User User) : IDomainEvent;
}
