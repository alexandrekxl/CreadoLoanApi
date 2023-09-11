using MediatR;
using Credo.Application.Loans.Common;
using ErrorOr;

namespace Credo.Application.Loans.Commands.Create
{
    public record CreateLoanCommand(
        int LoanType,
        decimal Amount,
        int Period,
        int Status,
        Guid UserId) : IRequest<ErrorOr<BaseResult>>;
}
