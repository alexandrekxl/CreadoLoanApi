using Credo.Domain.Common.Models;

namespace Credo.Domain.Loans.ValueObjects
{
    public sealed class LoanId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private LoanId(Guid value)
        {
            Value = value;
        }

        public static LoanId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static LoanId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Guid(LoanId data)
            => data.Value;
    }
}
