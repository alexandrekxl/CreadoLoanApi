using Credo.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Credo.Application.Authentication.Queries
{
    public record LoginQuery(
    string PersonalNumber,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
