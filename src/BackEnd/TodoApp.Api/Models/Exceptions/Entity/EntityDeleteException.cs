using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class EntityDeleteException : Exception
{
    public EntityDeleteException()
    {
    }

    public EntityDeleteException(string? message) : base(message)
    {
    }

    public EntityDeleteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}