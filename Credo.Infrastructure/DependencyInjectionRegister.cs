using Credo.Application.Common.Interfaces.Authentication;
using Credo.Application.Common.Interfaces.Persistence;
using Credo.Application.Common.Interfaces.Services;
using Credo.Infrastructure.Authentication;
using Credo.Infrastructure.Persistence;
using Credo.Infrastructure.Persistence.Interceptors;
using Credo.Infrastructure.Persistence.Repositories;
using Credo.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Credo.Infrastructure
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configration)
        {
            services
                .AddAuth(configration)
                .AddPersistence();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<CredoDbContext>(options => options.UseSqlServer("Server=localhost;Database=credo;Trusted_Connection=True"));


            services.AddScoped<PublishDomainEventsInterceptor>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configration)
        {
            var jwtSettings = new JwtSettings();
            configration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}
