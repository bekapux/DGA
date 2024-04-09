namespace DGA.Application.Features.Users.Commands;

public sealed record AddMovieToUserWatchlistCommand(Guid UserId, Guid MovieId) : UserMovieBaseCommand(UserId, MovieId), IRequest<ErrorOr<Success>>;

public sealed class AddMovieToUserWatchlistCommandAsyncValidator : AbstractValidator<AddMovieToUserWatchlistCommand>
{
    public AddMovieToUserWatchlistCommandAsyncValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .SetValidator(new UserMovieBaseCommandAsyncValidator(unitOfWork))
            .MustAsync(async (command, cancellationToken) =>
                {
                    var userMovieAlreadyExists = await unitOfWork.UserMovieRepository
                        .ExistsAsync(x => x.UserId == command.UserId && x.MovieId == command.MovieId, cancellationToken);
                    return !userMovieAlreadyExists;
                })
            .WithMessage("User already has this movie in the watchlist");
    }
}

public sealed class AddMovieToUserWatchlistCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddMovieToUserWatchlistCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(AddMovieToUserWatchlistCommand request, CancellationToken cancellationToken)
    {
        var userMovie = new UserMovie(request.UserId, request.MovieId);

        await unitOfWork.UserMovieRepository.AddAsync(userMovie, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}
