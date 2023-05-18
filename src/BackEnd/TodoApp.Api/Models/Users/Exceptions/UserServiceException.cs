using System.Runtime.Serialization;

namespace TodoApp.Api.Models.Users.Exceptions;

[Serializable]
public class UserServiceException : Exception
{
    public UserServiceException(Exception innerException) : base("Service error occurred, contact support.", innerException)
    {
    }

    protected UserServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}