using Credo.Domain.LoansAggregate.Entities;

namespace Credo.Application.Common.Interfaces.Persistence
{
    public interface ILoanTypesRepository
    {
        Task<IReadOnlyList<LoanTypes>> GetAll();
        Task<LoanTypes?> GetById(int id);
    }
}
