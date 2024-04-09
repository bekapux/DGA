namespace DGA.Infrastructure.Database.Seed;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = Guid.Parse("484d3bbb-5d7e-4f79-abcf-49a134467259"),
                Firstname = "Beka",
                Email = "beka@example.com",
                Lastname = "Pukhashvili"
            },
            new User
            {
                Id = Guid.Parse("e328e89b-b810-442f-a886-6343d21d4367"),
                Firstname = "Lasha",
                Email = "lasha@example.com",
                Lastname = "Pukhashvili"
            }
        );
    }
}