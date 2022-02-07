namespace MDDPlatform.SharedKernel.Exceptions{
    public class EmptyStringException : Exception
    {
        public EmptyStringException(string? message) : base(message)
        {
        }
    }
}