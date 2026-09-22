using FluentValidation.Results;
namespace BankingSystem.Application.Common.Results
{
    public static class ValidationErrorExtensions
    {
        public static IReadOnlyList<Error> ToErrors(this ValidationResult validationResult)
            => validationResult.Errors
                .Select(failure => Error.Validation(
                    $"Validation.{failure.PropertyName}",
                    failure.ErrorMessage))
                .ToList();
    }
}
