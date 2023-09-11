using FluentValidation;

namespace Credo.Application.Loans.Commands.Update
{
    public class UpdateLoanCommandValidator : AbstractValidator<UpdateLoanCommand>
    {
        public UpdateLoanCommandValidator()
        {
            RuleFor(e => e.ID).NotEmpty();
        }
    }
}
