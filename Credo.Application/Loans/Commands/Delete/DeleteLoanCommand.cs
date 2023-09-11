using ErrorOr;
using MediatR;

namespace Credo.Application.Loans.Commands.Delete
{
    public record DeleteLoanCommand(Guid Id) :
        IRequest<ErrorOr<Unit>>;
}
