using Credo.Domain.Users;

namespace Credo.Application.Authentication.Common
{
    public record AuthenticationResult(
    User User,
    string Token);
}
