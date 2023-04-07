namespace Domain.Exceptions
{
    public sealed class AlreadyExistsLibraryWithSameNameException : Exception
    {
        public AlreadyExistsLibraryWithSameNameException(string message) : base(message) { }
    }
}
