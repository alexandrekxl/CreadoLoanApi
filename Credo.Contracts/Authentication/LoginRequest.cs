namespace Credo.Contracts.Authentication
{
    public record LoginRequest(
    string PersonalNumber,
    string Password);
}
