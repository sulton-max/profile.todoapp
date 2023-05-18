namespace TodoApp.Api.Models.Users.Exceptions;

public class FailedUserServiceException : Exception
{
    public FailedUserServiceException(Exception innerException) : base("User service failed, contact support", innerException)
    {
    }
}