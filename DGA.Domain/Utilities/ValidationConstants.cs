namespace DGA.Domain.Utilities;

public static class ValidationConstants
{
    public static class User
    {
        public const int UserFirstnameMaxLength = 50;
        public const int UserLastnameMaxLength = 50;
        public const int EmailMaxLength = 50;
    }

    public static class Movie
    {
        public const int TitleMaxLength = 100;
        public const int DescriptionMaxLength = 500;
        public const int DirectorFullnameLength = 100;
    }
}