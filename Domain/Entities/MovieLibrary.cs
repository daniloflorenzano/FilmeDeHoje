using Domain.Exceptions;

namespace Domain.Entities
{
    public class MovieLibrary
    {
        public string Name { get; set; } = "Untitled";
        public List<Movie> Movies { get; set; } = new();

        public void AddMovies(Movie movie)
        {
            if (Movies.Contains(movie))
                throw new MovieAlreadyExistsInLibraryException($"Movie {movie.Title} already exists in library.");

            Movies.Add(movie);
        }

        public void AddMovies(List<Movie> movies)
        {
            if (Movies.Any(movies.Contains))
                throw new MovieAlreadyExistsInLibraryException(
                    $"Movie {movies.FirstOrDefault(movie => Movies.Contains(movie))!.Title} already exists in library.");

            Movies.AddRange(movies);
        }

        public void RemoveMovies(Movie movie)
        {
            if (!Movies.Contains(movie))
                throw new MovieDoesntExistsInLibraryException($"Movie {movie.Title} doesn't exists in library.");

            Movies.Remove(movie);
        }

        public void RemoveMovies(List<Movie> moviesToRemove)
        {
            foreach (var movie in moviesToRemove)
            {
                if (!Movies.Contains(movie))
                    throw new MovieDoesntExistsInLibraryException($"Movie {movie.Title} doesn't exists in library.");

                Movies.Remove(movie);
            }
        }
    }
}
