using BankingSystem.Application.Abstractions.Persistence;

namespace BankingSystem.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankingDbContext _context;
        public UnitOfWork(BankingDbContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
            => _context.SaveChangesAsync(cancellationToken);

    }
}
