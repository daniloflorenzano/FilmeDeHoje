namespace Domain.Exceptions
{
    public sealed class MovieDoesntExistsInLibraryException : Exception
    {
        public MovieDoesntExistsInLibraryException(string message) : base(message) { }
    }
}
