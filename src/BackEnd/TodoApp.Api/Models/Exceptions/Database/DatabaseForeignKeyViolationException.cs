using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Database;

[Serializable]
public class DatabaseForeignKeyViolationException : Exception
{
    public DatabaseForeignKeyViolationException()
    {
    }

    public DatabaseForeignKeyViolationException(string? message) : base(message)
    {
    }

    public DatabaseForeignKeyViolationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DatabaseForeignKeyViolationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}