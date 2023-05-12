using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class InvalidEntityException : Exception
{
    public InvalidEntityException()
    {
    }

    public InvalidEntityException(string? message) : base(message)
    {
    }

    public InvalidEntityException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InvalidEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}