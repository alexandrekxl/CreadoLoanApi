using Credo.Application.Loans.Commands.Create;
using Credo.Application.Loans.Common;
using ErrorOr;
using MediatR;

namespace Credo.Application.Loans.Commands.Update
{
    public record UpdateLoanCommand(
        Guid ID,
        CreateLoanCommand Data) : IRequest<ErrorOr<BaseResult>>;
}
