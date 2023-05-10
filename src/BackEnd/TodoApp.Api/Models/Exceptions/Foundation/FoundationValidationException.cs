using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Foundation;

[Serializable]
public class FoundationValidationException : Exception
{
    public FoundationValidationException()
    {
    }

    public FoundationValidationException(Exception innerException) : base(null, innerException)
    {
    }

    public FoundationValidationException(string? message) : base(message)
    {
    }

    public FoundationValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected FoundationValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}