using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Users.Exceptions;

[Serializable]
public class UserValidationException : Exception
{
    public UserValidationException(Exception innerException) : base("Invalid user, contact support", innerException)
    {
    }

    protected UserValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}