using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Database;

[Serializable]
public class DatabaseDuplicateKeyException : Exception
{
    public DatabaseDuplicateKeyException()
    {
    }

    public DatabaseDuplicateKeyException(string? message) : base(message)
    {
    }

    public DatabaseDuplicateKeyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DatabaseDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}