namespace Transport.Application.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string entityName)
           : base($"{entityName} exists")
        {
        }
    }
}
