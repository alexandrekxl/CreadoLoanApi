using Credo.Application.Common.Interfaces;
using Credo.Application.Common.Interfaces.Persistence;
using Credo.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Credo.Infrastructure.Persistence.UnitOfWork
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly CredoDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly ILoanStatusRepository _loanStatusRepository;
        private readonly ILoanTypesRepository _loanTypesRepository;

        public UnitOfWork(
            CredoDbContext dbContext,
            IUserRepository userRepository,
            ILoanRepository loanRepository,
            ILoanStatusRepository loanStatusRepository,
            ILoanTypesRepository loanTypesRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _loanRepository = loanRepository;
            _loanStatusRepository = loanStatusRepository;
            _loanTypesRepository = loanTypesRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public ILoanRepository LoanRepository => _loanRepository;
        public ILoanStatusRepository LoanStatusRepository => _loanStatusRepository;
        public ILoanTypesRepository LoanTypesRepository => _loanTypesRepository;



        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
