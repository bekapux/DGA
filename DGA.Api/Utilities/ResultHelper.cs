namespace DGA.Api.Utilities;

public static class ResultHelper
{
    public static IResult ToResult(this ErrorOr<Success> result)
    {
        return result.MatchFirst(
            onValue: _ => Results.Accepted(),
            onFirstError: ToErrorResult);
    }

    public static IResult ToResult<T>(this ErrorOr<T> result)
    {
        return result.MatchFirst(
            onValue: Results.Ok,
            onFirstError: ToErrorResult);
    }

    private static IResult ToErrorResult(Error error)
    {
        return error switch
        {
            { Type: ErrorType.Forbidden } => Results.Forbid(),
            { Type: ErrorType.Unauthorized } => Results.Unauthorized(),
            { Type: ErrorType.NotFound } => Results.NotFound(error.Description),
            { Type: ErrorType.Validation } => Results.BadRequest(error.Description),
            { Type: ErrorType.Failure } => Results.Problem(statusCode: 500, detail: error.Description),
            _ => Results.Problem("Something went wrong", statusCode: 500)
        };
    }
}
