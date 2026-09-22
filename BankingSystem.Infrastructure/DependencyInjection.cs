using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Security;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Infrastructure.Persistence.Repositories;
using BankingSystem.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
