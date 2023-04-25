using Domain.Exceptions;
using Domain.Entities;

namespace xUnitTests.Core
{
    public class MovieCollectionTest
    {
        private readonly List<Movie> _movies;

        public MovieCollectionTest()
        {
            _movies = MoviesToTest.All();
        }

        [Fact]
        public void Add_Movies()
        {
            var movieCollection = new MovieCollection();
            var movies = _movies;
            movieCollection.AddMovies(movies);

            Assert.All(movies, movie => Assert.Contains(movie, movieCollection.Movies));
        }

        [Fact]
        public void Add_Movie_That_Already_Exists()
        {
            var movieCollection = new MovieCollection { Movies = _movies };
            var movies = _movies;
            Assert.Throws<MovieAlreadyExistsInCollectionException>(() => movieCollection.AddMovies(movies));
        }

        [Fact]
        public void Remove_Movies()
        {
            var movieCollection = new MovieCollection { Movies = _movies };
            var moviesToRemove = new List<Movie> { _movies[0], _movies[1] };
            movieCollection.RemoveMovies(moviesToRemove);

            var moviesExpected = _movies.Except(moviesToRemove);
            Assert.Equal(moviesExpected, movieCollection.Movies);
        }

        [Fact]
        public void Remove_Movie_That_Does_Not_Exist()
        {
            var movieCollection = new MovieCollection { Movies = _movies };
            var moviesToRemove = new List<Movie> { new("A", "B", "Action, Comedy, Crime", 2020, 84, 75, ""), new("C", "D", "Action, Comedy, Crime", 2020, 84, 75, "") };

            Assert.Throws<MovieDoesntExistsInCollectionException>(() => movieCollection.RemoveMovies(moviesToRemove));
        }

        [Fact]
        public void Add_Collaborators()
        {
            var movieCollection = new MovieCollection();
            var users = new List<User> { new("Fulano", "fulano@email", "passwd"), new("Beutrano", "beutrano@email", "passwd") };
            movieCollection.AddCollaborators(users);

            Assert.All(users, user => Assert.Contains(user, movieCollection.Collaborators));
        }

        [Fact]
        public void Remove_Collaborators()
        {
            var movieCollection = new MovieCollection
            {
                Collaborators = new List<User> { new("Fulano", "fulano@email", "passwd"), new("Beutrano", "beutrano@email", "passwd") }
            };

            var usersToRemove = new List<User> { movieCollection.Collaborators[0] };
            movieCollection.RemoveCollaborators(usersToRemove);

            var collaboratorsExpected = movieCollection.Collaborators.Except(usersToRemove);
            Assert.Equal(collaboratorsExpected, movieCollection.Collaborators);
        }

        [Fact]
        public void Add_Collaborator_That_Already_Exists()
        {
            var movieCollection = new MovieCollection
            {
                Collaborators = new List<User> { new("Fulano", "fulano@email", "passwd") }
            };

            var users = new List<User> { movieCollection.Collaborators[0] };

            Assert.Throws<AlreadyExistsCollaboratorException>(() => movieCollection.AddCollaborators(users));
        }

        [Fact]
        public void Remove_Collaborator_That_Does_Not_Exists()
        {
            var movieCollection = new MovieCollection();
            var usersToRemove = new List<User> { new("Fulano", "fulano@email", "passwd") };

            Assert.Throws<CollaboratorDoesntExistsException>(() => movieCollection.RemoveCollaborators(usersToRemove));
        }
    }
}