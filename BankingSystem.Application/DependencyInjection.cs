using BankingSystem.Application.Services.Auth;
using BankingSystem.Application.Validators.AuthValidator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
