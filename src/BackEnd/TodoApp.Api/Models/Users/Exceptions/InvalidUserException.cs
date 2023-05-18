namespace TodoApp.Api.Models.Users.Exceptions;

public class InvalidUserException : Exception
{
    public InvalidUserException(string parameterName, object parameterValue) : base(
        $"Invalid user, parameter name: {parameterName}, parameter value: {parameterValue}.")
    {
    }
}