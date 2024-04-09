namespace DGA.Application.Interfaces;

public interface IMovieRepository : IGenericRepository<Movie>
{
    Task<List<UserMovie>> GetMoviesByUserId(Guid userId, CancellationToken cancellationToken = default);
}
