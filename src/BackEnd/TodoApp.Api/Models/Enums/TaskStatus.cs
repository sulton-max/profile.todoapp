namespace TodoApp.Api.Models.Enums;

/// <summary>
/// Represents task status
/// </summary>
public enum TaskStatus
{
    /// <summary>
    /// Indicates task is not started yet
    /// </summary>
    Todo,

    /// <summary>
    /// Indicates task is in progress
    /// </summary>
    InProgress,

    /// <summary>
    /// Indicates task is complete
    /// </summary>
    Done,

    /// <summary>
    /// Indicates task is deferred
    /// </summary>
    Deferred,

    /// <summary>
    /// Indicates task is cancelled
    /// </summary>
    Cancelled
}