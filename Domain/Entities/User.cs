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

        public User(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                throw new InvalidUserException("User cannot be created with empty fields");

            Name = name;
            Email = ValidadeEmail(email);
            Password = password;
        }

        private string ValidadeEmail(string email)
        {
            if (!email.Contains("@"))
                throw new InvalidEmailExcpetion("Email is invalid");

            return email;
        }

        public void AddMovieLibrary(MovieCollection movieLibrary)
        {
            if (MovieLibraries.Any(x => x.Name == movieLibrary.Name))
                throw new AlreadyExistsCollectionWithSameNameException($"Movie Library named {movieLibrary.Name} already exists");
            
            MovieLibraries.Add(movieLibrary);
        }

        public void RemoveMovieLibrary(MovieCollection movieLibrary)
        {
            if (MovieLibraries.All(m => m.Name != movieLibrary.Name))
                throw new CollectionDoesntExistsException($"Movie Library named {movieLibrary.Name} doesn't exists");

            MovieLibraries.Remove(movieLibrary);
        }
    }
}
