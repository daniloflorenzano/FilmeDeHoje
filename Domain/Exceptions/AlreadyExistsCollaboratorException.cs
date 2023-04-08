namespace Domain.Exceptions
{
    public sealed class AlreadyExistsCollaboratorException : Exception
    {
        public AlreadyExistsCollaboratorException(string message) : base(message) { }
    }
}
