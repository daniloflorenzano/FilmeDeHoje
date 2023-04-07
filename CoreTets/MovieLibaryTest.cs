using Domain.Exceptions;
using Domain.Entities;

namespace xUnitTests.Core
{
    public class MovieLibaryTest
    {
        private readonly List<Movie> _movies;

        public MovieLibaryTest()
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
        public void Add_New_Movie()
        {
            var movieLibary = new MovieLibrary();
            var movie = _movies[0];
            movieLibary.AddMovies(movie);

            Assert.Contains(movie, movieLibary.Movies);
        }

        [Fact]
        public void Add_Multiple_Movies()
        {
            var movieLibary = new MovieLibrary();
            var movies = _movies;
            movieLibary.AddMovies(movies);

            Assert.Equal(movies, movieLibary.Movies);
        }

        [Fact]
        public void Add_Movie_That_Already_Exists()
        {
            var movieLibary = new MovieLibrary { Movies = _movies };
            var movie = _movies[0];

            Assert.Throws<MovieAlreadyExistsInLibraryException>(() => movieLibary.AddMovies(movie));
        }

        [Fact]
        public void Add_Multiple_Movies_That_Already_Exists()
        {
            var movieLibary = new MovieLibrary { Movies = _movies };
            var movies = _movies;
            Assert.Throws<MovieAlreadyExistsInLibraryException>(() => movieLibary.AddMovies(movies));
        }

        [Fact]
        public void Remove_Movie()
        {
            var movieLibary = new MovieLibrary { Movies = _movies };
            var movieToRemove = _movies[0];
            movieLibary.RemoveMovies(movieToRemove);

            Assert.DoesNotContain(movieToRemove, movieLibary.Movies);
        }

        [Fact]
        public void Remove_Multiple_Movies()
        {
            var movieLibary = new MovieLibrary { Movies = _movies };
            var moviesToRemove = new List<Movie> { _movies[0], _movies[1] };
            movieLibary.RemoveMovies(moviesToRemove);

            var moviesExpected = _movies.Except(moviesToRemove);
            Assert.Equal(moviesExpected, movieLibary.Movies);
        }

        [Fact]
        public void Remove_Movie_That_Does_Not_Exist()
        {
            var movieLibary = new MovieLibrary { Movies = _movies };
            var movieToRemove = new Movie("", "", "Action, Comedy, Crime", 2020, 84, 75);
            
            Assert.Throws<MovieDoesntExistsInLibraryException>(() => movieLibary.RemoveMovies(movieToRemove));
        }

        [Fact]
        public void Remove_Multiple_Movies_That_Does_Not_Exist()
        {
            var movieLibary = new MovieLibrary { Movies = _movies };
            var moviesToRemove = new List<Movie> { new Movie("", "", "Action, Comedy, Crime", 2020, 84, 75), new Movie("", "", "Action, Comedy, Crime", 2020, 84, 75) };

            Assert.Throws<MovieDoesntExistsInLibraryException>(() => movieLibary.RemoveMovies(moviesToRemove));
        }
    }
}