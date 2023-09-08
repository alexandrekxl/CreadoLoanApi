namespace Credo.Contracts.Authentication
{
    public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token,
    string PersonalNumber,
    DateTime Birthdate);
}
