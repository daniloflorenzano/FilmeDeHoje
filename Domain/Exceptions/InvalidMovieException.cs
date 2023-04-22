namespace Domain.Exceptions
{
    public sealed class InvalidMovieException : Exception
    {
        public InvalidMovieException(string message) : base(message) { }
    }
}
