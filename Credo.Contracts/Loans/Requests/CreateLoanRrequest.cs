namespace Credo.Contracts.Loans.Requests
{
    public record CreateLoanRequest(
        int LoanType,
        decimal Amount,
        int Period,
        int Status,
        Guid UserId);
}
