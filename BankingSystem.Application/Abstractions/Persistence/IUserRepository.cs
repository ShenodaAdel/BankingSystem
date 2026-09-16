using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Abstractions.Persistence
{
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string normalizedEmail, CancellationToken cancellationToken = default);
        Task AddAsync(User user, CancellationToken cancellationToken = default);
    }
}
