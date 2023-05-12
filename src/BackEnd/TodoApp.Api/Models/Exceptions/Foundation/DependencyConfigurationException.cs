using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Exceptions.Foundation;

[Serializable]
public class DependencyConfigurationException : Exception
{
    public DependencyConfigurationException()
    {
    }
    
    public DependencyConfigurationException(Exception innerException) : base(null, innerException)
    {
    }


    public DependencyConfigurationException(string? message) : base(message)
    {
    }

    public DependencyConfigurationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DependencyConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}