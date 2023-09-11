using Credo.Application.Common.Interfaces;
using Credo.Application.Loans.Commands.Update;
using Credo.Application.Loans.Common;
using Credo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Credo.Application.Loans.Commands.Updare
{
    public class UpdateLoanCommandHandler :
        IRequestHandler<UpdateLoanCommand, ErrorOr<BaseResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLoanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<BaseResult>> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _unitOfWork.LoanRepository.GetById(request.ID);
            if (loan.Status == 3 || loan.Status == 4) 
            {
                return Errors.Loan.UpdateError;
            }

            await _unitOfWork.LoanRepository.Update(loan);

            return new BaseResult(loan.Id.Value);
        }
    }
}
