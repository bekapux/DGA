namespace DGA.Api;

public static partial class Controllers
{
    private static RouteGroupBuilder User(this RouteGroupBuilder group)
    {
        group.MapPost("add-movie-to-watchlist",
        async (ISender sender, AddMovieToUserWatchlistCommand command, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(command, cancellationToken);
            return result.ToResult();
        })
            .AddGenericMetadata<OkResult>("Add movie to the watchlist", "Adds movie to the user's watchlist");

        group.MapPost("mark-movie-as-seen",
        async (ISender sender, MarkMovieAsSeenCommand command, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(command, cancellationToken);
            return result.ToResult();
        })
            .AddGenericMetadata<OkResult>("Mark movie as seen", "Marks movie in the watchlist as seen");

        return group;
    }
}
