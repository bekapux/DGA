namespace DGA.Infrastructure.Database.Seed;

public sealed class UserMovieSeed : IEntityTypeConfiguration<UserMovie>
{
    public void Configure(EntityTypeBuilder<UserMovie> builder)
    {
        builder.HasData(
          new UserMovie(userId: Guid.Parse("484d3bbb-5d7e-4f79-abcf-49a134467259"), movieId: Guid.Parse("2b5c9bfb-332a-4841-9a35-1c52f669473b"), isSeen: true),
          new UserMovie(userId: Guid.Parse("484d3bbb-5d7e-4f79-abcf-49a134467259"), movieId: Guid.Parse("792dbafe-b439-41e8-9379-176d89f5d04d"), isSeen: false),
          new UserMovie(userId: Guid.Parse("484d3bbb-5d7e-4f79-abcf-49a134467259"), movieId: Guid.Parse("0345fa26-b2a8-4dad-8109-48084181eb90"), isSeen: true),
          new UserMovie(userId: Guid.Parse("e328e89b-b810-442f-a886-6343d21d4367"), movieId: Guid.Parse("2b5c9bfb-332a-4841-9a35-1c52f669473b"), isSeen: true),
          new UserMovie(userId: Guid.Parse("e328e89b-b810-442f-a886-6343d21d4367"), movieId: Guid.Parse("792dbafe-b439-41e8-9379-176d89f5d04d"), isSeen: false)
        );
    }
}
