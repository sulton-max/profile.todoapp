using TodoApp.Api.Models.Common;
using TodoApp.Api.Models.Enums;
using TaskStatus = TodoApp.Api.Models.Enums.TaskStatus;

namespace TodoApp.Api.Models.TodoTask;

/// <summary>
/// Represents a task with status
/// </summary>
public class TodoTask : IEntity
{
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the task
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the task
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets related category
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets current status
    /// </summary>
    public TaskStatus Status { get; set; }

    /// <summary>
    /// Gets or sets current priority
    /// </summary>
    public TaskPriority Priority { get; set; }

    /// <summary>
    /// Gets or sets the date of creation
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the date of last update
    /// </summary>
    public DateTime UpdatedDate { get; set; }

    /// <summary>
    /// Gets or sets the due date
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Related user Id
    /// </summary>
    public Guid AssignedUserId { get; set; }
}