namespace Domain.Exceptions
{
    public sealed class MovieAlreadyExistsInCollectionException : Exception
    {
        public MovieAlreadyExistsInCollectionException(string message) : base(message) { }
    }
}
