using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class EntityConcurrencyException : Exception
{
    public EntityConcurrencyException()
    {
    }

    public EntityConcurrencyException(string? message) : base(message)
    {
    }

    public EntityConcurrencyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}