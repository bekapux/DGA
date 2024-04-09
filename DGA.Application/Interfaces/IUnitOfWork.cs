namespace DGA.Application.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IMovieRepository MovieRepository { get; }
    IUserMovieRepository UserMovieRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
