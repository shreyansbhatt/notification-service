namespace NotificationService.Application;

public class Result<T> : Result
{
    public T Data { get; private set; }

    protected Result(bool success, List<string>? errors, T data)
        : base(success, errors)
    {
        Data = data;
    }

    public static Result<T> SuccessResult(T data)
    {
        return new Result<T>(true, null, data);
    }

    public static new Result<T> Failure(List<string> errors)
    {
        return new Result<T>(false, errors, default!);
    }

    public static new Result<T> Failure(string error)
    {
        return new Result<T>(false, [error], default!);
    }
}
