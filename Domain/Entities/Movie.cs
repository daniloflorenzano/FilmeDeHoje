using Domain.Exceptions;

namespace Domain.Entities
{
    public sealed class Movie
    {
        public string Title { get; }
        public string Description { get; }
        public string Genre { get; }
        public int Year { get; }
        public int AudienceScore { get; set; }
        public int CriticScore { get; set; }
        public string Poster { get; set; }

        public Movie(string title, string description, string genre, int year, int audienceScore, int criticScore, string poster)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(genre) || year == 0)
                throw new InvalidMovieException("Movie cannot be created with empty fields");

            if (DateTime.Now.Year < year)
                throw new InvalidMovieException("Movie cannot be created with future year");

            Title = title;
            Description = description;
            Genre = genre;
            Year = year;
            AudienceScore = audienceScore;
            CriticScore = criticScore;
            Poster = poster;
        }
    }
}
