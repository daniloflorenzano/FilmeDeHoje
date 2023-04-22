using Domain.Exceptions;
using Domain.Entities;

namespace xUnitTests.Core
{
    public class MovieTest
    {
        [Fact]
        public void Cannot_Create_Movie_With_With_Empty_Fields()
        {
            Assert.Throws<InvalidMovieException>(() => new Movie("", "", "", 0, 0, 0));
        }

        [Fact]
        public void Cannot_Create_Movie_With_With_Future_Year()
        {
            var futureYear = DateTime.Now.Year + 1;

            Assert.Throws<InvalidMovieException>(() => new Movie("Title", "Description", "Genre", futureYear, 0, 0));
        }
    }
}