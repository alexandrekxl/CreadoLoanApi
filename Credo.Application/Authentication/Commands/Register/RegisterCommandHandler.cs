using Credo.Application.Authentication.Common;
using Credo.Application.Common.Interfaces.Authentication;
using Credo.Application.Common.Interfaces.Persistence;
using Credo.Domain.Common.Errors;
using Credo.Domain.Users;
using ErrorOr;
using MediatR;

namespace Credo.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = User.Create(
                command.FirstName,
                command.LastName,
                command.Email,
                command.Password,
                command.PersonalNumber,
                command.BirthDate);

            _userRepository.AddUser(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
