namespace DGA.Infrastructure.Database.Seed;

public sealed class MovieSeed : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasData(
            new Movie
            {
                Id = Guid.Parse("2b5c9bfb-332a-4841-9a35-1c52f669473b"),
                Title = "Movie 1",
                Description = "Description of Movie 1",
                ReleaseYear = 2021,
                Director = "Director 1"
            },
            new Movie
            {
                Id = Guid.Parse("792dbafe-b439-41e8-9379-176d89f5d04d"),
                Title = "Movie 2",
                Description = "Description of Movie 2",
                ReleaseYear = 2022,
                Director = "Director 2"
            },
            new Movie
            {
                Id = Guid.Parse("0345fa26-b2a8-4dad-8109-48084181eb90"),
                Title = "Movie 3",
                Description = "Description of Movie 3",
                ReleaseYear = 2023,
                Director = "Director 3"
            }
        );
    }
}
