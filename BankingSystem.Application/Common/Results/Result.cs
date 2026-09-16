namespace BankingSystem.Application.Common.Results
{
    public class Result
    {
        protected Result(bool isSuccess, IEnumerable<Error> errors)
        {
            ArgumentNullException.ThrowIfNull(errors);

            // Read-only copy, so the errors cannot be changed after the result is created.
            IReadOnlyList<Error> errorList = [.. errors];

            if (errorList.Any(error => error is null))
                throw new ArgumentException("Errors cannot contain null.", nameof(errors));

            if (isSuccess && errorList.Count > 0)
                throw new ArgumentException("A successful result cannot contain errors.", nameof(errors));

            if (!isSuccess && errorList.Count == 0)
                throw new ArgumentException("A failed result must contain at least one error.", nameof(errors));

            IsSuccess = isSuccess;
            Errors = errorList;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public IReadOnlyList<Error> Errors { get; }

        // The first error, for the common single-error case.
        public Error Error => Errors.Count > 0 ? Errors[0] : Error.None;

        public static Result Success() => new(true, []);
        public static Result Failure(Error error) => new(false, [error]); // Single error
        public static Result Failure(IEnumerable<Error> errors) => new(false, errors);

        public static Result<T> Success<T>(T value) => Result<T>.Success(value);
        public static Result<T> Failure<T>(Error error) => Result<T>.Failure(error);
        public static Result<T> Failure<T>(IEnumerable<Error> errors) => Result<T>.Failure(errors);

        public static implicit operator Result(Error error) => Failure(error);
    }

    public sealed class Result<T> : Result
    {
        private readonly T? _value;

        private Result(bool isSuccess, T? value, IEnumerable<Error> errors)
            : base(isSuccess, errors)
        {
            _value = value;
        }

        // Throws instead of returning null so a failed result is never used by mistake.
        public T Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failed result cannot be accessed.");

        public static Result<T> Success(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "A successful result must have a value. Return an Error instead.");

            return new(true, value, []);
        }
        public static new Result<T> Failure(Error error) => new(false, default, [error]);
        public static new Result<T> Failure(IEnumerable<Error> errors) => new(false, default, errors);

        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator Result<T>(Error error) => Failure(error);
    }

}