namespace Credo.Contracts.Loans.Responses
{
    public record LoanResponse(
        int LoanType,
        decimal Amount,
        int Period,
        int Status,
        Guid UserId);
}
