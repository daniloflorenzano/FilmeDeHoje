using Domain.Exceptions;

namespace Domain.Entities
{
    public sealed class User
    {
        public List<MovieLibrary> MovieLibraries { get; set; } = new();

        public void AddMovieLibrary(MovieLibrary movieLibrary)
        {
            if (MovieLibraries.Any(x => x.Name == movieLibrary.Name))
                throw new AlreadyExistsLibraryWithSameNameException($"Movie Library named {movieLibrary.Name} already exists");
            
            MovieLibraries.Add(movieLibrary);
        }
    }
}
