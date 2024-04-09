namespace DGA.Infrastructure.Repositories;

public class UserRepository(DgaDbContext context) : GenericRepository<User>(context), IUserRepository
{
}
