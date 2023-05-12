using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Foundation;

[Serializable]
public class DependencyException : Exception
{
    public DependencyException()
    {
    }
    
    public DependencyException(Exception innerException) : base(null, innerException)
    {
    }


    public DependencyException(string? message) : base(message)
    {
    }

    public DependencyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DependencyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}