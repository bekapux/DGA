namespace DGA.Api;

public static partial class Controllers
{
    public static void UseMinimalControllers(this WebApplication app)
    {
        app.MapGroup("api/movie")
            .Movie()
            .WithTags("Movie");

        app.MapGroup("api/user")
            .User()
            .WithTags("User");
    }
}
