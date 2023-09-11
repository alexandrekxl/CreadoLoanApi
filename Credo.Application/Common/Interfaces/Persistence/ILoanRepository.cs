using Credo.Domain.Loans;

namespace Credo.Application.Common.Interfaces.Persistence
{
    public interface ILoanRepository
    {
        Task<Loan?> GetById(Guid id);
        Task Add(Loan loan);
        Task Update(Loan loan);
        void Delete(Loan loan);
        Task<IReadOnlyList<Loan>> GetAll();
    }
}
