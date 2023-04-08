namespace Domain.Exceptions
{
    public sealed class CollaboratorDoesntExistsException : Exception
    {
        public CollaboratorDoesntExistsException(string message) : base(message) { }
    }
}
