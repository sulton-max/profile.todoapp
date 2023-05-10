using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class EntityDuplicateException : Exception
{
    public EntityDuplicateException()
    {
    }

    public EntityDuplicateException(string? message) : base(message)
    {
    }

    public EntityDuplicateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityDuplicateException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}