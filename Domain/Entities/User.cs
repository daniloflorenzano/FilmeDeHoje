using Domain.Exceptions;

namespace Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<MovieCollection> MovieLibraries { get; set; } = new();

        public User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void AddMovieLibrary(MovieCollection movieLibrary)
        {
            if (MovieLibraries.Any(x => x.Name == movieLibrary.Name))
                throw new AlreadyExistsCollectionWithSameNameException($"Movie Library named {movieLibrary.Name} already exists");
            
            MovieLibraries.Add(movieLibrary);
        }
    }
}
