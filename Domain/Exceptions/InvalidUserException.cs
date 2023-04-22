namespace Domain.Exceptions
{
    public sealed class InvalidUserException : Exception
    {
        public InvalidUserException(string message) : base(message) { }
    }
}
