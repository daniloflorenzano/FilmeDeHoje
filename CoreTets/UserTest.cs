using Domain.Exceptions;
using Domain.Entities;

namespace xUnitTests.Core
{
    public class UserTest
    {
        [Fact]
        public void Add_MovieLibrary()
        {
            var user = new User();
            var movieLibrary = new MovieLibrary();
            user.AddMovieLibrary(movieLibrary);

            Assert.Contains(movieLibrary, user.MovieLibraries);
        }

        [Fact]
        public void Add_MovieLibrary_With_Same_Name()
        {
            var user = new User();
            var movieLibrary = new MovieLibrary { Name = "My Library" };
            user.AddMovieLibrary(movieLibrary);

            Assert.Throws<AlreadyExistsLibraryWithSameNameException>(() => user.AddMovieLibrary(movieLibrary));
        }
    }
}