using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credo.Application.Loans.Commands.Delete
{
    internal class DeleteLoanCommandValidator : AbstractValidator<DeleteLoanCommand>
    {
        public DeleteLoanCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}
