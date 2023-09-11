using Credo.Domain.LoansAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credo.Infrastructure.Persistence.Configurations
{
    internal class LoanStatusesConfiguration : IEntityTypeConfiguration<LoanStatuses>
    {
        public void Configure(EntityTypeBuilder<LoanStatuses> builder)
        {
            builder
                .ToTable("LoanStatuses");

            builder
                .HasKey(ls => ls.Id);

            builder
                .Property(ls => ls.StatusName);

            builder.HasData(
                new LoanStatuses
                {
                    Id = 1,
                    StatusName = "გადაგზავნილი"
                },
                new LoanStatuses
                {
                    Id= 2,
                    StatusName = "დამუშავების პროცესში"
                },
                new LoanStatuses
                {
                    Id= 3,
                    StatusName = "დამტკიცებული"
                },
                new LoanStatuses
                {
                    Id = 4,
                    StatusName = "უარყოფილი"
                });
        }
    }
}
