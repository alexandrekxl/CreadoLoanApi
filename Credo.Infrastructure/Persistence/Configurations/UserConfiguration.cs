using Credo.Domain.Loans;
using Credo.Domain.Users;
using Credo.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Credo.Infrastructure.Persistence.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
            ConfigureUserLoanIdsTable(builder);
        }

        

        private static void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder
                 .ToTable(nameof(User));

            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    Id => Id.Value,
                    value => UserId.Create(value));

            builder
            .Property(u => u.FirstName)
            .HasMaxLength(50);

            builder
                .Property(u => u.LastName)
                .HasMaxLength(50);

            builder
                .Property(u => u.Email)
                .HasMaxLength(150);

            builder
                .Property(u => u.Password);

            builder
                .Property(u => u.BirthDate);

            builder
                .Property(u => u.PersonalNumber)
                .HasMaxLength(50);

            builder.Metadata
            .FindNavigation(nameof(User.LoanIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureUserLoanIdsTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(u => u.LoanIds, Ul =>
            {
                Ul.WithOwner()
                  .HasForeignKey("LoanIds");

                Ul.ToTable("UserLoanIds");

                Ul.HasKey("Id");

                Ul.Property(mi => mi.Value)
                  .ValueGeneratedNever()
                  .HasColumnName("LoanID");
            });
        }
    }
}
