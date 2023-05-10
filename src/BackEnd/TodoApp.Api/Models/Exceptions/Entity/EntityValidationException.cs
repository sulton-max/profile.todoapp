using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class EntityValidationException : Exception
{
    public EntityValidationException()
    {
    }

    public EntityValidationException(string? message) : base(message)
    {
    }

    public EntityValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}