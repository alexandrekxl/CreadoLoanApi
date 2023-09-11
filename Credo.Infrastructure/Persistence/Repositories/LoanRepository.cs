using Credo.Application.Common.Interfaces.Persistence;
using Credo.Domain.Loans;
using Microsoft.EntityFrameworkCore;

namespace Credo.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly CredoDbContext _dbContext;

        public LoanRepository(CredoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Loan?> GetById(Guid Id)
        {
            return await _dbContext.Loans.FirstOrDefaultAsync(l => l.Id.Equals(Id));
        }

        public async Task Add(Loan loan)
        {
            await _dbContext.Loans.AddAsync(loan);
        }

        public void Delete(Loan loan)
        {
            _dbContext.Loans.Remove(loan);
        }

        public async Task<IReadOnlyList<Loan>> GetAll()
        {
            return await _dbContext.Loans.ToListAsync();
        }

        public async Task Update(Loan loan)
        {
            _dbContext.Loans.Entry(loan).State = EntityState.Modified;
        }
    }
}
