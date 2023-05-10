using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Api.Models.Exceptions.Foundation;

[Serializable]
public class FoundationFailedOperationException : Exception
{
    public FoundationFailedOperationException()
    {
    }

    public FoundationFailedOperationException(Exception innerException) : base(null, innerException)
    {
    }

    public FoundationFailedOperationException(string message) : base(message)
    {
    }

    public FoundationFailedOperationException(string message, Exception inner) : base(message, inner)
    {
    }

    protected FoundationFailedOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}