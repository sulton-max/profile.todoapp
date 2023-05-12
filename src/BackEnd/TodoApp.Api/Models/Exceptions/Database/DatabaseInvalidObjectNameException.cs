using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Database;

[Serializable]
public class DatabaseInvalidObjectNameException : Exception
{
    public DatabaseInvalidObjectNameException()
    {
    }

    public DatabaseInvalidObjectNameException(string? message) : base(message)
    {
    }

    public DatabaseInvalidObjectNameException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DatabaseInvalidObjectNameException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}