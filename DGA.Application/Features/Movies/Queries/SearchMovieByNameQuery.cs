namespace DGA.Application.Features.Movies.Queries;

public sealed record SearchMovieByNameQuery(string? SearchValue) : IRequest<ErrorOr<List<MovieDto>>>;

public sealed class SearchMovieByNameQueryValidator : AbstractValidator<SearchMovieByNameQuery>
{
    public SearchMovieByNameQueryValidator()
    {
        RuleFor(x => x.SearchValue)
            .MinimumLength(1)
            .WithMessage("Include at least 1 characters");
    }
}

public sealed class SearchMovieByNameQueryHandler(IMovieRepository movieRepository) : IRequestHandler<SearchMovieByNameQuery, ErrorOr<List<MovieDto>>>
{
    public async Task<ErrorOr<List<MovieDto>>> Handle(SearchMovieByNameQuery request, CancellationToken cancellationToken)
    {
        var movies = await movieRepository.GetWhereAsync(
            x => x.Title!.Contains(request.SearchValue!),
            cancellationToken);

        if (movies.Count is 0)
        {
            return Error.NotFound(code: "Movie.NotFound", description: "Movie with provided title was not found");
        }

        return movies
            .Select(x=> new MovieDto(x.Id, x.Title, x.Description, x.ReleaseYear, x.Director)) // Or Automapper / Mapster
            .ToList();
    }
}
