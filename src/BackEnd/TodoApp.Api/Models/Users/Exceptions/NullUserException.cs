using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Users.Exceptions;

[Serializable]
public class NullUserException : Exception
{
    public NullUserException() : base("User is null")
    {
    }

    protected NullUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}