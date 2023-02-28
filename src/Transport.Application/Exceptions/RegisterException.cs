namespace Transport.Application.Exceptions
{
    public class RegisterException : Exception
    {
        private const string _message = "Registration error!";

        public RegisterException()
            : base(_message) { }

        public RegisterException(Exception innerException)
            : base(_message, innerException) { }
    }
}
