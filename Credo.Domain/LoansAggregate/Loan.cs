using Credo.Domain.Common.Models;
using Credo.Domain.Loans.ValueObjects;
using Credo.Domain.Users.ValueObjects;

namespace Credo.Domain.Loans
{
    public sealed class Loan : AggregateRoot<LoanId, Guid>
    {
        public int LoanType { get; private set;}
        public decimal Amount { get; private set;}
        public int Period { get; private set;}
        public int Status { get; private set;}
        public UserId UserId { get; private set;}

        private Loan (
            LoanId Id,
            int loanType,
            decimal amount,
            int period,
            int status,
            UserId userID)
            : base(Id)
        {
            LoanType = loanType;
            Amount = amount;
            Period = period;
            Status = status;
            UserId = userID;
        }

        public static Loan Create(
            int loanType,
            decimal amount,
            int period,
            int status,
            UserId userId)
        {
            return new(
                LoanId.CreateUnique(),
                loanType,
                amount,
                period,
                status,
                userId);
        }
        public Loan() { }         
    }                             
}
