using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Api.Models.Exceptions.Entity;

[Serializable]
public class EntityLockedException : Exception
{
    public EntityLockedException()
    {
    }

    public EntityLockedException(DbUpdateConcurrencyException innerException) : base(null, innerException)
    {
    }

    public EntityLockedException(string? message) : base(message)
    {
    }

    public EntityLockedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}