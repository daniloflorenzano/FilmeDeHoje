using Domain.Exceptions;

namespace Domain.Entities
{
    public class MovieCollection
    {

        public string Name { get; set; } = "Untitled";
        public List<Movie> Movies { get; set; } = new();
        public User Owner { get; set; }
        public List<User> Collaborators { get; set; } = new();

        public MovieCollection() { }

        public MovieCollection(string name, User owner, List<User> collaborators)
        {
            Name = name;
            Owner = owner;
            Collaborators = collaborators;
        }


        public void AddMovies(List<Movie> movies)
        {
            if (Movies.Any(movies.Contains))
                throw new MovieAlreadyExistsInCollectionException(
                    $"Movie {movies.FirstOrDefault(movie => Movies.Contains(movie))!.Title} already exists in library.");

            Movies.AddRange(movies);
        }

        public void RemoveMovies(List<Movie> moviesToRemove)
        {
            foreach (var movie in moviesToRemove)
            {
                if (!Movies.Contains(movie))
                    throw new MovieDoesntExistsInCollectionException($"Movie {movie.Title} doesn't exists in library.");

                Movies.Remove(movie);
            }
        }

        public void AddCollaborators(List<User> users)
        {
            foreach (var user in users)
            {
                if (Collaborators.Contains(user))
                    throw new AlreadyExistsCollaboratorException($"User {user.Name} is already a collaborator.");

                Collaborators.Add(user);
            }
        }

        public void RemoveCollaborators(List<User> usersToRemove)
        {
            foreach (var user in usersToRemove)
            {
                if (!Collaborators.Contains(user))
                    throw new CollaboratorDoesntExistsException($"User {user.Name} is not a collaborator.");

                Collaborators.Remove(user);
            }
        }
    }
}
