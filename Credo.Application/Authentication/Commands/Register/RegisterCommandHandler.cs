using Credo.Application.Authentication.Common;
using Credo.Application.Common.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_unitOfWork.UserRepository.GetUserByPersonalNumber(command.PersonalNumber).Result is not null)
            {
                return Errors.User.DuplicateUser;
            }

            var user = User.Create(
                command.FirstName,  
                command.LastName,
                command.Email,
                command.Password,
                command.PersonalNumber,
                command.BirthDate);

            await _unitOfWork.UserRepository.AddUser(user);

            await _unitOfWork.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
