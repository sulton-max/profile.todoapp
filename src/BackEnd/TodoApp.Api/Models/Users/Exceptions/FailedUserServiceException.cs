using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Users.Exceptions;

[Serializable]
public class FailedUserServiceException : Exception
{
    public FailedUserServiceException(Exception innerException) : base("User service failed, contact support", innerException)
    {
    }
    
    protected FailedUserServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}