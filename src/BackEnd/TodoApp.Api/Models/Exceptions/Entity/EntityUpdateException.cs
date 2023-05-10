using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class EntityUpdateException : Exception
{
    public EntityUpdateException()
    {
    }

    public EntityUpdateException(string? message) : base(message)
    {
    }

    public EntityUpdateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}