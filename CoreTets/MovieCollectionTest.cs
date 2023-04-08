using Domain.Exceptions;
using Domain.Entities;

namespace xUnitTests.Core
{
    public class MovieCollectionTest
    {
        private readonly List<Movie> _movies;

        public MovieCollectionTest()
        {
            _movies = new List<Movie>
            {
                new("I See You", "Strange occurrences plague a small-town detective and his family as he investigates the disappearance of a boy.", "Mystery & thriller", 2019, 73, 75),
                new("Luther: The Fallen Sun", "In Luther: The Fallen Sun -- an epic continuation of the award-winning television saga reimagined for film -- a gruesome serial killer is terrorizing London while brilliant but disgraced detective John Luther (Idris Elba) sits behind bars. Haunted by his failure to capture the cyber psychopath who now taunts him, Luther decides to break out of prison to finish the job by any means necessary.", "Crime, Drama, Mystery & thriller", 2023, 85, 67),
                new("The Last Thing He Wanted", "A reporter stumbles upon a story involving a former CIA operative and a senator who may have been involved in a secret arms deal.", "Crime, Drama, Mystery & thriller", 2020, 13, 5),
                new("RRR", "The story of freedom fighters Komaram Bheem and Alluri Sitarama Raju.", "Action, Drama", 2022, 94, 95),
                new("The Gentlemen", "An American expat tries to sell off his highly profitable marijuana empire in London, triggering plots, schemes, bribery and blackmail in an attempt to steal his domain out from under him.", "Action, Comedy, Crime", 2020, 84, 75),
            };
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
            var moviesToRemove = new List<Movie> { new("", "", "Action, Comedy, Crime", 2020, 84, 75), new Movie("", "", "Action, Comedy, Crime", 2020, 84, 75) };

            Assert.Throws<MovieDoesntExistsInCollectionException>(() => movieCollection.RemoveMovies(moviesToRemove));
        }

        [Fact]
        public void Add_Collaborators()
        {
            var movieCollection = new MovieCollection();
            var users = new List<User> { new("Fulano", "", ""), new User("Beutrano", "", "") };
            movieCollection.AddCollaborators(users);

            Assert.All(users, user => Assert.Contains(user, movieCollection.Collaborators));
        }

        [Fact]
        public void Remove_Collaborators()
        {
            var movieCollection = new MovieCollection
            {
                Collaborators = new List<User> { new User("Fulano", "", ""), new User("Beutrano", "", "") }
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
                Collaborators = new List<User> { new("Fulano", "", "") }
            };

            var users = new List<User> { movieCollection.Collaborators[0] };

            Assert.Throws<AlreadyExistsCollaboratorException>(() => movieCollection.AddCollaborators(users));
        }

        [Fact]
        public void Remove_Collaborator_That_Does_Not_Exists()
        {
            var movieCollection = new MovieCollection();
            var usersToRemove = new List<User> { new("Fulano", "", "") };

            Assert.Throws<CollaboratorDoesntExistsException>(() => movieCollection.RemoveCollaborators(usersToRemove));
        }
    }
}