using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Users.Exceptions;

[Serializable]
public class AlreadyExistsUserException : Exception
{
    public AlreadyExistsUserException(Exception innerException) : base("User with the same id already exists.", innerException)
    {
    }

    protected AlreadyExistsUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}