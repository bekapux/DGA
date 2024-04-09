namespace DGA.Api;

public static partial class Controllers
{
    private static RouteGroupBuilder Movie(this RouteGroupBuilder group)
    {
        group.MapGet("{searchValue}",
        async (ISender sender, string searchValue, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new SearchMovieByNameQuery(searchValue), cancellationToken);
            return result.ToResult();
        })
            .AddMetadata<List<MovieDto>>("Search movies", "Searches movies based on the provided search value");

        group.MapGet("user-movies/{userId:Guid}",
        async (ISender sender, Guid userId, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new GetMoviesByUserIdQuery(userId), cancellationToken);
            return result.ToResult();
        })
            .AddMetadata<List<MovieDto>>("Get user's watchlist", "Returns movies that the user has added to their watchlist, along with whether each movie has been seen.");

        return group;
    }
}
