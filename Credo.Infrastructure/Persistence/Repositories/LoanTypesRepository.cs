using Credo.Application.Common.Interfaces.Persistence;
using Credo.Domain.LoansAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Credo.Infrastructure.Persistence.Repositories
{
    public class LoanTypesRepository : ILoanTypesRepository
    {
        private readonly CredoDbContext _dbContext;

        public LoanTypesRepository(CredoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<LoanTypes>> GetAll()
        {
            return await _dbContext.LoanTypes.ToListAsync();
        }

        public async Task<LoanTypes?> GetById(int Id)
        {
            return await _dbContext.LoanTypes.FirstOrDefaultAsync(lt => lt.Id == Id);
        }
    }
}
