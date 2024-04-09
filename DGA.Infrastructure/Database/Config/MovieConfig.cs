namespace DGA.Infrastructure.Database.Config;

public class MovieConfig : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(ValidationConstants.Movie.TitleMaxLength);

        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(ValidationConstants.Movie.DescriptionMaxLength);

        builder.Property(m => m.ReleaseYear)
            .IsRequired();

        builder.Property(m => m.Director)
            .IsRequired()
            .HasMaxLength(ValidationConstants.Movie.DirectorFullnameLength);;

        builder.HasMany(m => m.UserMovies)
            .WithOne(um => um.Movie)
            .HasForeignKey(um => um.MovieId);
    }
}