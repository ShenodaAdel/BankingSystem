using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Persistence.Configurations
{
    public class EmailConfirmationConfiguration : IEntityTypeConfiguration<EmailConfirmation>
    {
        public void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            builder.HasKey(ec => ec.Id);

            builder.Property(ec => ec.TokenHash)
                .IsRequired()
                .HasMaxLength(64)
                .IsFixedLength()
                .IsUnicode(false);

            builder.HasIndex(ec => ec.TokenHash)
                .IsUnique();

            builder.Property(ec => ec.ExpiresAt)
                .IsRequired();

            builder.HasOne(ec => ec.User)
                .WithMany(u => u.EmailConfirmations)
                .HasForeignKey(ec => ec.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
