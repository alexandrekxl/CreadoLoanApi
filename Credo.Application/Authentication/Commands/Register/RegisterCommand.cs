using Credo.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Credo.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PersonalNumber,
    DateTime BirthDate) : IRequest<ErrorOr<AuthenticationResult>>;
}
