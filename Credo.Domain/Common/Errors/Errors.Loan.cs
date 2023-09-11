using ErrorOr;


namespace Credo.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Loan 
        {
            public static Error UpdateError => Error.Conflict(
                code: "Loan.Rejected/approved",
                description: "Cant update rejected and Approved records");

            public static Error RecordNotFound => Error.Conflict(
                code: "Loan.NotFound",
                description: "Loan with not found");
        }

    }
}
