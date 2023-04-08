namespace Domain.Exceptions
{
    public sealed class AlreadyExistsCollectionWithSameNameException : Exception
    {
        public AlreadyExistsCollectionWithSameNameException(string message) : base(message) { }
    }
}
