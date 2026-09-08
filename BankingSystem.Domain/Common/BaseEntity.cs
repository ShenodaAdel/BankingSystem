using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
            = DateTimeOffset.UtcNow;

        public DateTimeOffset? LastUpdatedAt { get; set; }
    }
}
