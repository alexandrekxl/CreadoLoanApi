using ErrorOr;

namespace Credo.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateUser => Error.Conflict(
                code: "User.DuplicateUser",
                description: "User Already Registered.");
        }
    }
}
