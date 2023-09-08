using Credo.Domain.Loans;
using Credo.Domain.Loans.ValueObjects;
using Credo.Domain.Users;
using Credo.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Credo.Infrastructure.Persistence.Configurations
{
    public sealed class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable(nameof(Loan));

            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    Id => Id.Value,
                    value => LoanId.Create(value));

            builder
                .Property(l => l.LoanType);

            builder
                .Property(l => l.Amount)
                .HasColumnType("decimal(18,4)");

            builder
                .Property(l => l.Period);

            builder
                .Property(l => l.Status);

            builder
               .Property(u => u.UserId)
               .HasConversion(
                   Id => Id.Value,
                   value => UserId.Create(value));

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .IsRequired();
        }
    }
}
