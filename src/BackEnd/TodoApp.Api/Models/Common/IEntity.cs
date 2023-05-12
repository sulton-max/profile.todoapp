namespace TodoApp.Api.Models.Common;

/// <summary>
/// Defines common properties for all entities
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Gets or sets the primary Id of the entity
    /// </summary>
    public Guid Id { get; set; }
}