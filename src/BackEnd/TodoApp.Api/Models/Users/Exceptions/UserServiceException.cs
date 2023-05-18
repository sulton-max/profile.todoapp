namespace TodoApp.Api.Models.Users.Exceptions;

public class UserServiceException : Exception
{
    public UserServiceException(Exception innerException) : base("Service error occurred, contact support.", innerException)
    {
    }
}