using BankingSystem.Domain.Common;
using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private static readonly DateTimeOffset SeededAt = new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.NormalizedEmail)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasIndex(u => u.NormalizedEmail)
                .IsUnique();

            builder.Property(u => u.Phone)
                .HasMaxLength(20);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
            new
                {
                    Id = Guid.Parse(DefaultUsers.Admin.Id),
                    FirstName = DefaultUsers.Admin.FirstName,
                    LastName = DefaultUsers.Admin.LastName,
                    Email = DefaultUsers.Admin.Email,
                    NormalizedEmail = DefaultUsers.Admin.NormalizedEmail,
                    PasswordHash = DefaultUsers.Admin.PasswordHash,
                    Phone = DefaultUsers.Admin.Phone,
                    RoleId = Guid.Parse(DefaultUsers.Admin.RoleId),
                    IsActive = DefaultUsers.Admin.IsActive,
                    AccessFailedCount = DefaultUsers.Admin.AccessFailedCount,
                    CreatedAt = SeededAt
                });
        }
    }
}
