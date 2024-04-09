namespace DGA.Infrastructure.Database;

public sealed class DgaDbContext(DbContextOptions<DgaDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DgaDbContext).Assembly);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<UserMovie> UserMovies { get; set; }
}
