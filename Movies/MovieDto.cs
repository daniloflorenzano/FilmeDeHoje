namespace Movies;

public record MovieDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public int AudienceScore { get; set; }
    public int CriticScore { get; set; }
    public string Poster { get; set; }
};