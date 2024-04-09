using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Text.Json;
using ValidationException = FluentValidation.ValidationException;

namespace DGA.Api;

public static class ExceptionHandling
{
    public static void HandleExceptions(this WebApplication app)
    {
        app.UseExceptionHandler(handler =>
        {
            handler.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                (int httpStatusCode, string response, string contentType) = GetHttpStatusCodeAndErrors(exceptionHandlerPathFeature?.Error);

                if (exceptionHandlerPathFeature?.Error is not ValidationException)
                {
                    Log.Error("Internal Server Error. Message: {Statuscode}, Stacktrace: {Stacktrace}",
                        exceptionHandlerPathFeature?.Error.Message,
                        exceptionHandlerPathFeature?.Error.StackTrace);
                }

                context.Response.ContentType = contentType;
                context.Response.StatusCode = httpStatusCode;

                await context.Response.WriteAsync(response);
            });
        });
    }

    private static (int httpStatusCode, string, string) GetHttpStatusCodeAndErrors(Exception? exception)
    {
        return exception switch
        {
            ValidationException validationException => FormatValidationException(validationException),
            _ => (StatusCodes.Status500InternalServerError, "Something went wrong", "text/plain")
        };
    }

    private static (int httpStatusCode, string, string) FormatValidationException(FluentValidation.ValidationException exception)
    {
        return exception.Errors.Count() is 1 ? (StatusCodes.Status400BadRequest, exception.Errors.First().ErrorMessage, "text/plain")
            : (StatusCodes.Status400BadRequest,
            JsonSerializer.Serialize(new { Errors = exception.Errors.Select(x => x.ErrorMessage) }), "application/json");
    }
}
