namespace NotificationService.Application;

public class Result
{
    public bool Success { get; private set; }
    public List<string> Errors { get; private set; } = [];

    protected Result(bool success, List<string>? errors)
    {
        Success = success;
        Errors = errors ?? [];
    }

    public static Result Failure(List<string> errors)
    {
        return new Result(false, errors);
    }

    public static Result Failure(string error)
    {
        return new Result(false, [error]);
    }

    public static Result SuccessResult()
    {
        return new Result(true, null);
    }
}
