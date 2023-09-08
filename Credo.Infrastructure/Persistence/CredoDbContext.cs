using Credo.Domain.Common.Models;
using Credo.Domain.Loans;
using Credo.Domain.Users;
using Credo.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Credo.Infrastructure.Persistence
{
    public class CredoDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

        public CredoDbContext()
        {
            
        }

        public CredoDbContext(
            DbContextOptions<CredoDbContext> options,
            PublishDomainEventsInterceptor publishDomainEventsInterceptor) 
                : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public DbSet<Loan> Loans { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(CredoDbContext).Assembly);



            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-UFORNDE;Database=credo;Trusted_Connection=True;Encrypt=false;Integrated Security=true;")
                .AddInterceptors(_publishDomainEventsInterceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
