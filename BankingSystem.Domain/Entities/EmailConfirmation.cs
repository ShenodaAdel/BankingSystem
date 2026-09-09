using BankingSystem.Domain.Common;
namespace BankingSystem.Domain.Entities
{
    public class EmailConfirmation : BaseEntity
    {
        public string TokenHash { get; set; } = null!;
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTimeOffset? ConsumedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
