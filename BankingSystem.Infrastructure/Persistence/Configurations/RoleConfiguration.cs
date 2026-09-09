using BankingSystem.Domain.Common;
using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        private static readonly DateTimeOffset SeededAt = new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(r => r.Name)
                .IsUnique();

            builder.HasData(
                new
                {
                    Id = Guid.Parse(DefaultRoles.Admin.Id),
                    Name = DefaultRoles.Admin.Name,
                    CreatedAt = SeededAt
                },
                new
                {
                    Id = Guid.Parse(DefaultRoles.Customer.Id),
                    Name = DefaultRoles.Customer.Name,
                    CreatedAt = SeededAt
                });

        }
    }
}
