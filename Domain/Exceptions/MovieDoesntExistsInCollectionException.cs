namespace Domain.Exceptions
{
    public sealed class MovieDoesntExistsInCollectionException : Exception
    {
        public MovieDoesntExistsInCollectionException(string message) : base(message) { }
    }
}
