using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class EntitySecurityException : Exception
{
    public EntitySecurityException()
    {
    }

    public EntitySecurityException(string? message) : base(message)
    {
    }

    public EntitySecurityException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntitySecurityException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}