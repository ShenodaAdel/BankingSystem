using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Services.Auth.Dtos
{
    public record RegisterResponse(Guid UserId, string Email);
}
