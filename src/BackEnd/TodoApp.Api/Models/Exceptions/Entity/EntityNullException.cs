using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class EntityNullException : Exception
{
    public EntityNullException()
    {
    }

    public EntityNullException(string? message) : base(message)
    {
    }

    public EntityNullException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityNullException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}