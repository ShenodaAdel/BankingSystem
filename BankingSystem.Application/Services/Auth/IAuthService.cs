using BankingSystem.Application.Common.Results;
using BankingSystem.Application.Services.Auth.Dtos;

namespace BankingSystem.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    }
}
