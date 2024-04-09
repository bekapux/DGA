namespace DGA.Application.Features.Movies.Queries;

public sealed record GetMoviesByUserIdQuery(Guid UserId) : IRequest<ErrorOr<IEnumerable<GetMoviesByUserIdResponse>>>;

public sealed class GetMoviesByUserIdQueryValidator : AbstractValidator<GetMoviesByUserIdQuery>
{
    public GetMoviesByUserIdQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
};

public record GetMoviesByUserIdResponse(
    Guid Id,
    string? Title,
    string? Description,
    int ReleaseYear,
    string? Director,
    bool IsSeen);

public sealed class GetMoviesByUserIdQueryHandler(IMovieRepository movieRepository) : IRequestHandler<GetMoviesByUserIdQuery, ErrorOr<IEnumerable<GetMoviesByUserIdResponse>>>
{
    public async Task<ErrorOr<IEnumerable<GetMoviesByUserIdResponse>>> Handle(GetMoviesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var result = await movieRepository.GetMoviesByUserId(request.UserId, cancellationToken);

        return result
            .Select(x=> new GetMoviesByUserIdResponse(
                x.Movie.Id, 
                x.Movie.Title, 
                x.Movie.Description, 
                x.Movie.ReleaseYear, 
                x.Movie.Director, 
                x.IsSeen))
            .ToList();
    }
}
