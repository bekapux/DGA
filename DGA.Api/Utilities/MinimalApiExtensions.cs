namespace DGA.Api.Utilities;

public static class MinimalApiExtensions
{
    public static RouteHandlerBuilder AddGenericMetadata<TSuccessResponseType>(
        this RouteHandlerBuilder builder,
        string operationSummary,
        string operationDescription)
    {
        return builder
            .WithMetadata(new SwaggerOperationAttribute(operationSummary, operationDescription))
            .WithMetadata(new ProducesResponseTypeAttribute(statusCode: 200, type: typeof(TSuccessResponseType)))
            .WithMetadata(new ProducesResponseTypeAttribute(statusCode: 400, type: typeof(string)))
            .WithMetadata(new ProducesResponseTypeAttribute(statusCode: 500, type: typeof(string)));
    }

    public static RouteHandlerBuilder AddNotFoundMetadata(
    this RouteHandlerBuilder builder)
    {
        return builder
            .WithMetadata(new ProducesResponseTypeAttribute(statusCode: 404, type: typeof(string)));
    }
}
