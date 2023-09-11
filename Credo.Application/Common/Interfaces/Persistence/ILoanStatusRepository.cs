using Credo.Domain.Loans;
using Credo.Domain.LoansAggregate.Entities;

namespace Credo.Application.Common.Interfaces.Persistence
{
    public interface ILoanStatusRepository 
    {
        Task<IReadOnlyList<LoanStatuses>> GetAll();

        Task<LoanStatuses?> GetById(int Id);
    }

}
