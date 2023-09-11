using Credo.Application.Loans.Common;
using ErrorOr;
using MediatR;

namespace Credo.Application.Loans.Queries
{
    public record GetLoanQuery(Guid id);
        //: IRequest<ErrorOr<>>;
}
