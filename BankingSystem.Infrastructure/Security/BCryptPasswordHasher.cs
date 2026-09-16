using BankingSystem.Application.Abstractions.Security;

namespace BankingSystem.Infrastructure.Security
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        // Matches the work factor of the seeded admin hash ($2a$11$).
        private const int WorkFactor = 11;

        public string Hash(string password)
            => BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);

        public bool Verify(string password, string passwordHash)
            => BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
