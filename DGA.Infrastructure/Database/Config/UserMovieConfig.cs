namespace DGA.Infrastructure.Database.Config;

public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
{
    public void Configure(EntityTypeBuilder<UserMovie> builder)
    {
        builder.ToTable("UserMovies");

        builder.HasKey(um => new { um.UserId, um.MovieId });

        builder.Property(um => um.IsSeen)
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasOne(um => um.User)
            .WithMany(u => u.UserMovies)
            .HasForeignKey(um => um.UserId);

        builder.HasOne(um => um.Movie)
            .WithMany(m => m.UserMovies)
            .HasForeignKey(um => um.MovieId);
    }
}
