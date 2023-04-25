using Movies.APIs.TheMovieDb;

namespace Movies;

public sealed class MoviesProvider
{
    public async Task<List<MovieDto>?> GetMoviesAsync(string title)
    {
        var theMovieDb = new TheMovieDbProvider();
        var movies = await theMovieDb.GetMovieAsync(title);
        return movies;
    }
}