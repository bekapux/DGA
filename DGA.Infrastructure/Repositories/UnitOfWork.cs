namespace DGA.Infrastructure.Repositories;

public class UnitOfWork(DgaDbContext context) : IUnitOfWork
{
    public IUserRepository UserRepository => new UserRepository(context);
    public IMovieRepository MovieRepository => new MovieRepository(context);
    public IUserMovieRepository UserMovieRepository => new UserMovieRepository(context);

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);
}
