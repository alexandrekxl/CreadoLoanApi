using Credo.Application.Authentication.Common;
using Credo.Application.Common.Interfaces.Authentication;
using Credo.Application.Common.Interfaces.Persistence;
using Credo.Domain.Users;
using Credo.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Credo.Application.Common.Interfaces;

namespace Credo.Application.Authentication.Queries
{
    public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var userFromDb = await _unitOfWork.UserRepository.GetUserByPersonalNumber(request.PersonalNumber);

            if (userFromDb is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != request.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
