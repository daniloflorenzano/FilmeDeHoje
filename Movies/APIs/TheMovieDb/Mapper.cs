namespace Movies.APIs.TheMovieDb;

public sealed class Mapper
{
    public static List<MovieDto>? ToMovieDtoList(TheMovieDbReturn? theMovieDbReturn)
    {
        if (theMovieDbReturn is null)
            return null;

        List<MovieDto> movieDtos = new();

        foreach (var movie in theMovieDbReturn.Movies)
        {
            MovieDto movieDto = new();
            movieDto.Title = movie.Title;
            movieDto.Description = movie.Plot;
            movieDto.Genre = movie.Genre;
            movieDto.Year = int.Parse(movie.Year);
            movieDto.AudienceScore = int.Parse(movie.imdbRating);
            movieDto.CriticScore = int.Parse(movie.Metascore);
            movieDto.Poster = movie.Poster;
            
            movieDtos.Add(movieDto);
        }

        return movieDtos;
    }   
}