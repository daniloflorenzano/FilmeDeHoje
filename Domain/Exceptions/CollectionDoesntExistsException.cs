namespace Domain.Exceptions
{
    public sealed class CollectionDoesntExistsException : Exception
    {
        public CollectionDoesntExistsException(string message) : base(message) { }
    }
}
