using Credo.Domain.LoansAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credo.Infrastructure.Persistence.Configurations
{
    internal class LoanTypesConfiguration : IEntityTypeConfiguration<LoanTypes>
    {
        public void Configure(EntityTypeBuilder<LoanTypes> builder)
        {
            builder
                .ToTable("LoanTypes");

            builder
                .HasKey(lt => lt.Id);

            builder
                .Property(lt => lt.LoanTypeName);

            builder.HasData(
                new LoanTypes
                {
                    Id = 1,
                    LoanTypeName = "სწრაფი სესხი"
                },
                new LoanTypes
                {
                    Id= 2,
                    LoanTypeName = "ავტო სესხი"
                },
                new LoanTypes
                {
                    Id= 3,
                    LoanTypeName = "განვადება"
                });
        }
    }
}
