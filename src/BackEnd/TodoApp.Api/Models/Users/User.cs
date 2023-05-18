using TodoApp.Api.Models.Common;

namespace TodoApp.Api.Models.Users;

/// <summary>
/// Represents a user of the system
/// </summary>
public class User : IEntity
{
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the email address
    /// </summary>
    public string EmailAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password 
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the username
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets user creation date
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets user last update date
    /// </summary>
    public DateTimeOffset UpdatedDate { get; set; }
}