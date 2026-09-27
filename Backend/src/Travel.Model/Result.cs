namespace Travel.Model
{
    public record Result
    {
        public bool IsSuccess { get; init; }

        public string ErrorMessage { get; init; }


        public Result(bool isSuccess, string errorMessage = "")
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }


    public record Result<TValue> : Result
    {
        public TValue? Value { get; init; }

        public Result(bool isSuccess, TValue? value, string errorMessage = "") : base(isSuccess, errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Value = value;
        }
    }
}
