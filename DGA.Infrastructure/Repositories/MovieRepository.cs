namespace DGA.Infrastructure.Repositories;

public sealed class MovieRepository(DgaDbContext context) : GenericRepository<Movie>(context), IMovieRepository
{
    public async Task<List<UserMovie>> GetMoviesByUserId(Guid userId, CancellationToken cancellationToken = default)
    {
        return await Context.Set<UserMovie>()
            .AsNoTracking()
            .Include(x => x.Movie)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}
