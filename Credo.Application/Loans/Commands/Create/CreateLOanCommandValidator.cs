using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credo.Application.Loans.Commands.Create
{
    public class CreateLOanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLOanCommandValidator()
        {
            RuleFor(l => l.LoanType).NotEmpty();
            RuleFor(l => l.Status).NotEmpty();
            RuleFor(l => l.Period).NotEmpty();
            RuleFor(l => l.Amount).NotEmpty();
            RuleFor(l => l.UserId).NotEmpty();
        }
    }
}
