using Credo.Api.Common.Errors;
using Credo.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Credo.Api
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            //services.AddSingleton<ProblemDetailsFactory, CredoProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}
