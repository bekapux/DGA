namespace DGA.Application.Features.Users.SharedValidators;

public abstract record UserMovieBaseCommand(Guid UserId, Guid MovieId);

public class UserMovieBaseCommandAsyncValidator : AbstractValidator<UserMovieBaseCommand>
{
    public UserMovieBaseCommandAsyncValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .SetValidator(new UserMovieBaseCommandValidator())
            .MustAsync(async (command, cancellationToken) =>
            {
                var movieExists = await unitOfWork.MovieRepository
                    .ExistsAsync(x => x.Id == command.MovieId, cancellationToken);
                return movieExists;
            })
            .WithMessage("Invalid Movie ID")
            .MustAsync(async (command, cancellationToken) =>
            {
                var userExists = await unitOfWork.UserRepository
                    .ExistsAsync(x => x.Id == command.UserId, cancellationToken);
                return userExists;
            })
            .WithMessage("Invalid User ID");
    }

    class UserMovieBaseCommandValidator : AbstractValidator<UserMovieBaseCommand>
    {
        public UserMovieBaseCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}