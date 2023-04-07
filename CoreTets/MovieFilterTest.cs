using Domain.Behaviors;
using Domain.Entities;

namespace xUnitTests.Core
{
    public class MovieFilterTest
    {
        private readonly List<Movie> _movies;

        public MovieFilterTest()
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
        public void Filter_By_Genre_Similarity()
        {
            var movieFilter = new MovieFilter(_movies);
            var genre = "Mystery";
            var movies = movieFilter.GetMoviesByGenre(genre);

            Assert.NotEmpty(movies);
            Assert.All(movies, movie => Assert.Contains(genre, movie.Genre));
        }

        [Fact]
        public void Filter_By_Year()
        {
            var movieFilter = new MovieFilter(_movies);
            var year = 2020;
            var movies = movieFilter.GetMoviesByYear(year);

            Assert.NotEmpty(movies);
            Assert.All(movies, movie => Assert.Equal(year, movie.Year));
        }

        [Fact]
        public void Filter_By_Audience_Score()
        {
            var movieFilter = new MovieFilter(_movies);
            var score = 80;
            var movies = movieFilter.GetMoviesByAudienceScore(score);

            Assert.NotEmpty(movies);
            Assert.All(movies, movie => Assert.True(movie.AudienceScore >= score));
        }

        [Fact]
        public void Filter_By_Critic_Score()
        {
            var movieFilter = new MovieFilter(_movies);
            var score = 80;
            var movies = movieFilter.GetMoviesByCriticScore(score);

            Assert.NotEmpty(movies);
            Assert.All(movies, movie => Assert.True(movie.CriticScore >= score));
        }
    }
}