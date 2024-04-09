namespace DGA.Application.Features.Movies;

public record MovieDto(
    Guid Id,
    string? Title,
    string? Description,
    int ReleaseYear,
    string? Director);
