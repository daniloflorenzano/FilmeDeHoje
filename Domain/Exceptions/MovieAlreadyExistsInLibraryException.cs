namespace Domain.Exceptions
{
    public sealed class MovieAlreadyExistsInLibraryException : Exception
    {
        public MovieAlreadyExistsInLibraryException(string message) : base(message) { }
    }
}
