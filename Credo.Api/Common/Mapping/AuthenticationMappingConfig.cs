using Credo.Application.Authentication.Commands.Register;
using Credo.Application.Authentication.Common;
using Credo.Contracts.Authentication;
using Mapster;

namespace Credo.Api.Common.Mapping
{
    public class AuthenticationMappingConfig
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, RegisterCommand>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
