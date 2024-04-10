namespace DGA.Api.Utilities;

public static class MinimalApiExtensions
{
    public static RouteHandlerBuilder AddDefaultMetadata<TSuccessResponseType>(
        this RouteHandlerBuilder builder,
        string operationSummary,
        string operationDescription)
    {
        int successStatusCode = typeof(TSuccessResponseType) == typeof(OkResult) ? 202 : 200;

        return builder
            .WithMetadata(new SwaggerOperationAttribute(operationSummary, operationDescription))
            .WithMetadata(new ProducesResponseTypeAttribute(statusCode: successStatusCode, type: typeof(TSuccessResponseType)))
            .WithMetadata(new ProducesResponseTypeAttribute(statusCode: 400, type: typeof(string)))
            .WithMetadata(new ProducesResponseTypeAttribute(statusCode: 500, type: typeof(string)));
    }

    public static RouteHandlerBuilder AddNotFoundMetadata(this RouteHandlerBuilder builder)
    {
        return builder
            .WithMetadata(new ProducesResponseTypeAttribute(statusCode: 404, type: typeof(string)));
    }
}
