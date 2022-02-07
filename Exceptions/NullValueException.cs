namespace MDDPlatform.SharedKernel.Exceptions{
    public class NullValueException : Exception
    {
        public NullValueException(string? message) : base(message)
        {
        }
    }
}