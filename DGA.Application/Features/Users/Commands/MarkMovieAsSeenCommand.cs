namespace DGA.Application.Features.Users.Commands;

public sealed record MarkMovieAsSeenCommand(Guid UserId, Guid MovieId) : UserMovieBaseCommand(UserId, MovieId), IRequest<ErrorOr<Success>>;

public sealed class MarkMovieAsSeenCommandValidator : AbstractValidator<MarkMovieAsSeenCommand>
{
    public MarkMovieAsSeenCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x)
            .SetValidator(new UserMovieBaseCommandAsyncValidator(unitOfWork));
    }
}

public sealed class MarkMovieAsSeenCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<MarkMovieAsSeenCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(MarkMovieAsSeenCommand request, CancellationToken cancellationToken)
    {
        var userMovie = await unitOfWork.UserMovieRepository
            .FirstOrDefaultAsync(x =>
                x.UserId == request.UserId
                && x.MovieId == request.MovieId, cancellationToken);

        if (userMovie is null)
        {
            return Error.Validation(description: "The movie is not in user's watchlist");
        }

        if (userMovie.IsSeen)
        {
            return Error.Validation(description: "The movie is already marked as 'seen'");
        }

        userMovie.IsSeen = true;
        unitOfWork.UserMovieRepository.Update(userMovie);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}
