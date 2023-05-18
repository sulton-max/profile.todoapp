using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Users.Exceptions;

[Serializable]
public class NotFoundUserException : Exception
{
    public NotFoundUserException(Guid guid) : base($"Couldn't find user with id {guid}.")
    {
    }

    protected NotFoundUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}