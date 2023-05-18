using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Users.Exceptions;

[Serializable]
public class UserDependencyException : Exception
{
    public UserDependencyException(Exception innerException) : base("Service dependency error occurred, contact support.", innerException)
    {
    }
    
    protected UserDependencyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}