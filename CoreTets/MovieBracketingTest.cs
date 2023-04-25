using Domain.Entities;
using Domain.UseCases;

namespace xUnitTests.Core
{
    public class MovieBracketingTest
    {
        private readonly List<Movie> _movies;

        public MovieBracketingTest()
        {
            _movies = MoviesToTest.All();
        }

        [Fact]
        public void Create_Bracketing_With_Even_Number_Of_Movies()
        {
            var bracketingHandler = new BracketingHandler();
            var bracketings = bracketingHandler.CreateBracket(_movies);

            Assert.Equal(3, bracketings.Item1.Count);
            Assert.Equal(3, bracketings.Item2.Count);
        }

        [Fact]
        public void Create_Bracketing_With_Odd_Number_Of_Movies()
        {
            _movies.Add(new("The Godfather: Part II", "A", "Crime", 1974, 98, 99, ""));
            var bracketingHandler = new BracketingHandler();
            var bracketings = bracketingHandler.CreateBracket(_movies);

            Assert.Equal(3, bracketings.Item1.Count);
            Assert.Equal(4, bracketings.Item2.Count);
        }
    }
}