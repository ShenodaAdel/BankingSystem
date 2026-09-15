using BankingSystem.Application.Common.Results;

namespace BankingSystem.Application.Common.Errors
{
    public static class AuthErrors
    {
        public static readonly Error InvalidCredentials =
            Error.Unauthorized(
                "Auth.InvalidCredentials",
                "Email or password is incorrect.");

        public static readonly Error EmailNotConfirmed =
            Error.Forbidden(
                "Auth.EmailNotConfirmed",
                "Confirm your email before logging in.");

        public static readonly Error AccountLocked =
            Error.Forbidden(
                "Auth.AccountLocked",
                "Your account is locked.");

        public static readonly Error InvalidRefreshToken =
            Error.Unauthorized(
                "Auth.InvalidRefreshToken",
                "The refresh token is invalid or expired.");

        public static readonly Error InvalidConfirmationLink =
            Error.Validation(
                "Auth.InvalidConfirmationLink",
                "The email confirmation link is invalid or expired.");

        public static readonly Error ConfirmationLinkAlreadyUsed =
            Error.Conflict(
                "Auth.ConfirmationLinkAlreadyUsed",
                "The email confirmation link has already been used.");
    }
}
