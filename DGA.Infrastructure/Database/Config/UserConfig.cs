namespace DGA.Infrastructure.Database.Config;

public sealed class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(x => x.Firstname)
            .HasMaxLength(ValidationConstants.User.UserFirstnameMaxLength);

        builder.Property(x => x.Lastname)
            .HasMaxLength(ValidationConstants.User.UserLastnameMaxLength);

        builder.Property(x => x.Email)
            .HasMaxLength(ValidationConstants.User.EmailMaxLength);
        
        builder.HasMany(m => m.UserMovies)
            .WithOne(um => um.User)
            .HasForeignKey(um => um.UserId);
    }
}
