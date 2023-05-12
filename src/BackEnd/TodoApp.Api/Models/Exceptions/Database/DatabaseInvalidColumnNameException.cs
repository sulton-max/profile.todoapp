using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Database;

[Serializable]
public class DatabaseInvalidColumnNameException : Exception
{
    public DatabaseInvalidColumnNameException()
    {
    }

    public DatabaseInvalidColumnNameException(string? message) : base(message)
    {
    }

    public DatabaseInvalidColumnNameException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DatabaseInvalidColumnNameException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}