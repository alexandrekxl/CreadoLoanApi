using Credo.Domain.Common.Models;
using Credo.Domain.Loans;

namespace Credo.Domain.LoansAggregate.Events
{
    public record LoanCreated(Loan loan) : IDomainEvent;
}
