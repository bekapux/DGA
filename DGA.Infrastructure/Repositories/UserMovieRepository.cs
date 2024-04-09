namespace DGA.Infrastructure.Repositories;

public sealed class UserMovieRepository(DgaDbContext dbContext) : GenericRepository<UserMovie>(dbContext), IUserMovieRepository
{
}
