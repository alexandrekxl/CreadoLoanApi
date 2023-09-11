using Credo.Application.Common.Constants;
using Credo.Application.Common.Interfaces;
using Credo.Application.Loans.Common;
using Credo.Domain.Loans;
using Credo.Domain.Users.ValueObjects;
using ErrorOr;
using MediatR;

namespace Credo.Application.Loans.Commands.Create
{
    internal class CreateLoanCommandHandler :
        IRequestHandler<CreateLoanCommand, ErrorOr<BaseResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLoanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<BaseResult>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loanStatus = _unitOfWork.LoanStatusRepository.GetAll().Result.ToList();
            var initialStatusId = loanStatus.First(ls => ls.StatusName == LoanStatuses.Sent).Id;

            var loan = Loan.Create(
                request.LoanType,
                request.Amount,
                request.Period,
                request.Status,
                UserId.Create(request.UserId));

            await _unitOfWork.LoanRepository.Add(loan);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResult(loan.Id.Value);
        }
    }
}
