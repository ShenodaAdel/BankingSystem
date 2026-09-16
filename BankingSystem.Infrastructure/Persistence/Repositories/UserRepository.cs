using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace BankingSystem.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankingDbContext _context;
        public UserRepository(BankingDbContext context)
        {
            _context = context;
        }
        public Task<bool> EmailExistsAsync(string normalizedEmail, CancellationToken cancellationToken = default)
            => _context.Users.AnyAsync(u => u.NormalizedEmail == normalizedEmail, cancellationToken);

        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
            => await _context.Users.AddAsync(user, cancellationToken);
    }
}
