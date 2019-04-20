namespace QuizWeb.Models
{
    public class Result
    {
        public int Code { get; protected set; }
        public string ErrorMessage { get; protected set; }

        public Result(int code, string errorMessage)
        {
            Code = code;
            ErrorMessage = errorMessage;
        }
    }

    public class SuccessResult<T> : Result 
    {
        public T Data;
        public SuccessResult(T data) : base(0, "OK")
        {
            Data = data;
        }
    }
}
