using BankingSystem.Domain.Common;

namespace BankingSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; private set; } = null!;
        public string NormalizedEmail { get; private set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Phone { get; set; }
        public Guid RoleId { get; set; }

        // Stays false until the user confirms their email.
        public bool IsActive { get; set; } 
        public int AccessFailedCount { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public Role Role { get; set; } = null!;
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public ICollection<EmailConfirmation> EmailConfirmations { get; set; } = new List<EmailConfirmation>();


        public void SetEmail(string email)
        {
            var normalizedInput = email.Trim();

            Email = normalizedInput;
            NormalizedEmail = normalizedInput.ToLowerInvariant();
        }

    }
}
