using System.Net.Http.Json;

namespace Movies.APIs.TheMovieDb;

public sealed class TheMovieDbProvider
{
    private const string ApiKey = "";
    private const string Uri = $"http://www.omdbapi.com/?apikey={ApiKey}&";

    public async Task<List<MovieDto>?> GetMovieAsync(string title)
    {
        var uri = $"{Uri}s={title}&type=movie";
        var response = await new HttpClient().GetFromJsonAsync<TheMovieDbReturn>(uri);

        List<Movie> movies = new();
        response?.Movies.ForEach(movie => movies.Add(movie));

        TheMovieDbReturn theMovieDbReturn = new()
        {
            Movies = movies
        };

        return Mapper.ToMovieDtoList(theMovieDbReturn);
    }
}