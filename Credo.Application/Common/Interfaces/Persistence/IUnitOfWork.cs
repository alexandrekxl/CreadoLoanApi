using Credo.Application.Common.Interfaces.Persistence;

namespace Credo.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILoanRepository LoanRepository { get; }
        ILoanStatusRepository LoanStatusRepository { get; }
        ILoanTypesRepository LoanTypesRepository { get; }

        Task SaveChangesAsync();
    }
}