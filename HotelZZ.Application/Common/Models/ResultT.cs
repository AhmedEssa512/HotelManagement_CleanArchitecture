
namespace HotelZZ.Application.Common.Models
{
    public class Result<T> : Result
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (IsFailure)
                    throw new InvalidOperationException("Cannot access Value of a failed result");
                return _value;
            }
        }

        protected internal Result(T value, bool isSuccess, List<string> errors)
            : base(isSuccess, errors)
        {
            _value = value;
        }

        public static Result<T> Success(T value)
            => new Result<T>(value, true, new List<string>());

        public static new Result<T> Failure(params string[] errors)
            => new Result<T>(default!, false, errors.ToList());
    }
}