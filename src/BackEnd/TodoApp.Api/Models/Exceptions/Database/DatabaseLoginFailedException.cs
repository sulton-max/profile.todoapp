using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Database;

[Serializable]
public class DatabaseLoginFailedException : Exception
{
    public DatabaseLoginFailedException()
    {
    }

    public DatabaseLoginFailedException(string? message) : base(message)
    {
    }

    public DatabaseLoginFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DatabaseLoginFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}