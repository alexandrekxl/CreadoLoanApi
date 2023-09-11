using Credo.Application.Common.Interfaces;
using Credo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Credo.Application.Loans.Commands.Delete
{
    internal class DeleteLoanRequestHandler : IRequestHandler<DeleteLoanCommand,ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLoanRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loanToDelete = await _unitOfWork.LoanRepository.GetById(request.Id);

            if (loanToDelete is null)
            {
                return Errors.Loan.RecordNotFound;
            }
            _unitOfWork.LoanRepository.Delete(loanToDelete);
            return Unit.Value;
        }
    }
}
