using Credo.Application.Common.Interfaces.Persistence;
using Credo.Domain.LoansAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Credo.Infrastructure.Persistence.Repositories
{
    public class LoanStatusesRepository : ILoanStatusRepository
    {
        private readonly CredoDbContext _dbContext;

        public LoanStatusesRepository(CredoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<LoanStatuses>> GetAll()
        {
            return await _dbContext.LoansStatuses.ToListAsync();
        }

        public async Task<LoanStatuses?> GetById(int Id)
        {
            return await _dbContext.LoansStatuses.FirstOrDefaultAsync(l => l.Id == Id);
        }


    }
}
