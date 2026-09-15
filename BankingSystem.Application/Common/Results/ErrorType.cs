namespace BankingSystem.Application.Common.Results
{
    public enum ErrorType
    {
        Failure,        // unexpected / generic
        Validation,     // bad request / invalid input
        NotFound,
        Conflict,       // e.g. email already registered
        Unauthorized,   // wrong credentials / not logged in
        Forbidden       // logged in, but not allowed
    }
}
