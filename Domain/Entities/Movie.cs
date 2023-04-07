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

        public Movie(string title, string description, string genre, int year, int audienceScore, int criticScore)
        {
            Title = title;
            Description = description;
            Genre = genre;
            Year = year;
            AudienceScore = audienceScore;
            CriticScore = criticScore;
        }
    }
}
