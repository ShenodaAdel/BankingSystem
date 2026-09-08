using BankingSystem.Domain.Common;

namespace BankingSystem.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string TokenHash { get; set; } = null!;
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTimeOffset? RevokedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
