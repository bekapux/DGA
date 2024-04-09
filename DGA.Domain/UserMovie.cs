namespace DGA.Domain;

public sealed class UserMovie(Guid userId, Guid movieId, bool isSeen = false)
{
    public Guid UserId { get; init; } = userId;
    public Guid MovieId { get; init; } = movieId;
    public bool IsSeen { get; set; } = isSeen;

    public User User { get; init; }
    public Movie Movie { get; init; }
}
