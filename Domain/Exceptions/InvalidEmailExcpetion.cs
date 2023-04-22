namespace Domain.Exceptions
{
    public sealed class InvalidEmailExcpetion: Exception
    {
        public InvalidEmailExcpetion(string message) : base(message) { }
    }
}
