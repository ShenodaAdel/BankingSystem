using BankingSystem.Application.Common.Results;

namespace BankingSystem.Application.Common.Errors
{
    public static class UserErrors
    {
        public static readonly Error NotFound =
            Error.NotFound(
                "User.NotFound",
                "User was not found.");

        public static readonly Error EmailAlreadyRegistered =
            Error.Conflict(
                "User.EmailAlreadyRegistered",
                "Email is already registered.");
    }
}
