using Credo.Domain.Common.Models;
using Credo.Domain.Loans.ValueObjects;
using Credo.Domain.Users.ValueObjects;

namespace Credo.Domain.Users
{
    public sealed class User : AggregateRoot<UserId, Guid>
    {
        private readonly List<LoanId> _loanIds = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PersonalNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public IReadOnlyList<LoanId> LoanIds => _loanIds.ToList();

        private User(
            UserId id,
            string firstName,
            string lastName,
            string email,
            string password,
            string personalNumber,
            DateTime birthDate)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
        }

        public static User Create(
            string firstName,
            string lastName,
            string email,
            string password,
            string personalNumber,
            DateTime birthDate)
        {
            return new(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password,
                personalNumber,
                birthDate);
        }

#pragma warning disable CS8618
        private User() { }
#pragma warning restore CS8618
    }
}
