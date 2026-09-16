namespace BankingSystem.Application.Services.Auth.Dtos
{
    public record RegisterRequest(string FirstName,
        string LastName,
        string Email,
        string Password, string PhoneNumber);
}
