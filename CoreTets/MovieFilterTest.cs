using Domain.Entities;
using Domain.UseCases;

namespace xUnitTests.Core
{
    public class MovieFilterTest
    {
        private readonly List<Movie> _movies;

        public MovieFilterTest()
        {
            _movies = MoviesToTest.All();
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