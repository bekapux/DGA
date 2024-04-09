using DGA.Domain.Utilities;

namespace DGA.Domain;

public class Movie : EntityBase
{
    public string Title { get; init; }  = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int ReleaseYear { get; init; }
    public string Director { get; init; } = string.Empty;

    public ICollection<UserMovie> UserMovies { get; init; } = [];
}
