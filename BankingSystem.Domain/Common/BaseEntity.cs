namespace BankingSystem.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset? LastUpdatedAt { get; private set; }
    }
}
