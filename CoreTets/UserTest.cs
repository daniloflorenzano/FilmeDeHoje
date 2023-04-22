using Domain.Exceptions;
using Domain.Entities;

namespace xUnitTests.Core
{
    public class UserTest
    {
        [Fact]
        public void Add_MovieLibrary()
        {
            var user = new User("Danilo", "daniloflorenzano1@gmail.com", "passwd");
            var movieLibrary = new MovieCollection();
            user.AddMovieLibrary(movieLibrary);

            Assert.Contains(movieLibrary, user.MovieLibraries);
        }

        [Fact]
        public void Add_MovieLibrary_With_Same_Name()
        {
            var user = new User("Danilo", "daniloflorenzano1@gmail.com", "passwd");
            var movieLibrary = new MovieCollection { Name = "My Library" };
            user.AddMovieLibrary(movieLibrary);

            Assert.Throws<AlreadyExistsCollectionWithSameNameException>(() => user.AddMovieLibrary(movieLibrary));
        }

        [Fact]
        public void Remove_MovieLibrary()
        {
            var user = new User("Danilo", "daniloflorenzano1@gmail.com", "passwd");
            var movieLibrary = new MovieCollection { Name = "My Library" };
            user.AddMovieLibrary(movieLibrary);
            user.RemoveMovieLibrary(movieLibrary);
            Assert.DoesNotContain(movieLibrary, user.MovieLibraries);
        }

        [Fact]
        public void Remove_MovieLibrary_That_Does_Not_Exist()
        {
            var user = new User("Danilo", "daniloflorenzano1@gmail.com", "passwd");
            var movieLibrary = new MovieCollection { Name = "My Library" };
            Assert.Throws<CollectionDoesntExistsException>(() => user.RemoveMovieLibrary(movieLibrary));
        }

        [Fact]
        public void Cannot_Create_User_With_With_Empty_Fields()
        {
            Assert.Throws<InvalidUserException>(() => new User("", "", ""));
        }

        [Fact]
        public void Cannot_Create_User_With_Invalid_Email()
        {
            Assert.Throws<InvalidEmailExcpetion>(() => new User("Danilo", "teste", "passwd"));
        }
    }
}