using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Foundation;

[Serializable]
public class DependencyValidationException : Exception
{
    public DependencyValidationException()
    {
    }

    public DependencyValidationException(Exception innerException) : base(null, innerException)
    {
    }

    public DependencyValidationException(string? message) : base(message)
    {
    }

    public DependencyValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DependencyValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}