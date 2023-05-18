using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Users.Exceptions;

[Serializable]
public class LockedUserException : Exception
{
    public LockedUserException(Exception innerException) : base("Locked calendar record exception, please try again", innerException)
    {
    }

    protected LockedUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}