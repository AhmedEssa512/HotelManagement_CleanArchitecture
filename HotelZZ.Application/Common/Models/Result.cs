
namespace HotelZZ.Application.Common.Models
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public List<string> Errors { get; }

        protected Result(bool isSuccess, List<string> errors)
        {
            if (isSuccess && errors.Any())
                throw new InvalidOperationException("Success result cannot have errors");

            if (!isSuccess && errors.Count == 0)
                throw new InvalidOperationException("Failure result must have at least one error");

            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result Success() => new Result(true, new List<string>());

        public static Result Failure(params string[] errors)
            => new Result(false, errors.ToList());

        public static Result Create(bool condition, params string[] errors)
            => condition ? Success() : Failure(errors);
    }
}