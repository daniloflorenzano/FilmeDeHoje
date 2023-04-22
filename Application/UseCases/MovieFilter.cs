using Domain.Entities;

namespace Domain.UseCases
{
    public sealed class MovieFilter
    {
        private readonly List<Movie> _movies;

        public MovieFilter(List<Movie> movies)
        {
            _movies = movies;
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            var movies = new List<Movie>();
            movies.AddRange(_movies.Where(movie => movie.Genre.Contains(genre)));
            return movies;
        }

        public List<Movie> GetMoviesByYear(int year)
        {
            var movies = new List<Movie>();
            movies.AddRange(_movies.Where(movie => movie.Year == year));
            return movies;
        }

        public List<Movie> GetMoviesByAudienceScore(int score)
        {
            var movies = new List<Movie>();
            movies.AddRange(_movies.Where(movie => movie.AudienceScore >= score));
            return movies;
        }

        public List<Movie> GetMoviesByCriticScore(int score)
        {
            var movies = new List<Movie>();
            movies.AddRange(_movies.Where(movie => movie.CriticScore >= score));
            return movies;
        }
    }
}
