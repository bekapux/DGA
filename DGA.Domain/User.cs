using DGA.Domain.Utilities;

namespace DGA.Domain;

public sealed class User : EntityBase
{
    public string Firstname { get; init; } = string.Empty;
    public string Lastname { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;

    public ICollection<UserMovie> UserMovies { get; init; } = [];
}
