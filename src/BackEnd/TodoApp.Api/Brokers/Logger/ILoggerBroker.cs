using TodoApp.Api.Models.Exceptions.Entity;

namespace TodoApp.Api.Brokers.Logger;

/// <summary>
/// Defines methods for logger broker
/// </summary>
public interface ILoggerBroker
{
    /// <summary>
    /// Formats and writes an critical log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogCritical<T>(string messageTemplate, T arg0);

    /// <summary>
    /// Formats and writes an critical log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogCritical<T>(string messageTemplate, T arg0, T arg1);

    /// <summary>
    /// Formats and writes an critical log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <param name="arg2">Argument 2</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogCritical<T>(string messageTemplate, T arg0, T arg1, T arg2);

    /// <summary>
    /// Formats and writes an critical log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="args">Arguments</param>
    void LogCritical(string messageTemplate, params object[] args);

    /// <summary>
    /// Formats and writes an error log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogError<T>(string messageTemplate, T arg0);

    /// <summary>
    /// Formats and writes an error log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogError<T>(string messageTemplate, T arg0, T arg1);

    /// <summary>
    /// Formats and writes an error log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <param name="arg2">Argument 2</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogError<T>(string messageTemplate, T arg0, T arg1, T arg2);

    /// <summary>
    /// Formats and writes an error log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="args">Arguments</param>
    void LogError(string messageTemplate, params object[] args);

    /// <summary>
    /// Logs exception
    /// </summary>
    /// <param name="exception">Exception</param>
    void LogError(Exception exception);

    /// <summary>
    /// Formats and writes an warning log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogWarning<T>(string messageTemplate, T arg0);

    /// <summary>
    /// Formats and writes an warning log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogWarning<T>(string messageTemplate, T arg0, T arg1);

    /// <summary>
    /// Formats and writes an warning log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <param name="arg2">Argument 2</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogWarning<T>(string messageTemplate, T arg0, T arg1, T arg2);

    /// <summary>
    /// Formats and writes an warning log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="args">Arguments</param>
    void LogWarning(string messageTemplate, params object[] args);

    /// <summary>
    /// Formats and writes an informational log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogInformation<T>(string messageTemplate, T arg0);

    /// <summary>
    /// Formats and writes an informational log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogInformation<T>(string messageTemplate, T arg0, T arg1);

    /// <summary>
    /// Formats and writes an informational log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <param name="arg2">Argument 2</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogInformation<T>(string messageTemplate, T arg0, T arg1, T arg2);

    /// <summary>
    /// Formats and writes an informational log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="args">Arguments</param>
    void LogInformation(string messageTemplate, params object[] args);

    /// <summary>
    /// Formats and writes an debug log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogDebug<T>(string messageTemplate, T arg0);

    /// <summary>
    /// Formats and writes an debug log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogDebug<T>(string messageTemplate, T arg0, T arg1);

    /// <summary>
    /// Formats and writes an debug log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <param name="arg2">Argument 2</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogDebug<T>(string messageTemplate, T arg0, T arg1, T arg2);

    /// <summary>
    /// Formats and writes an debug log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="args">Arguments</param>
    void LogDebug(string messageTemplate, params object[] args);

    /// <summary>
    /// Formats and writes an trace log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogTrace<T>(string messageTemplate, T arg0);

    /// <summary>
    /// Formats and writes an trace log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogTrace<T>(string messageTemplate, T arg0, T arg1);

    /// <summary>
    /// Formats and writes an trace log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="arg0">Argument 0</param>
    /// <param name="arg1">Argument 1</param>
    /// <param name="arg2">Argument 2</param>
    /// <typeparam name="T">Argument type</typeparam>
    void LogTrace<T>(string messageTemplate, T arg0, T arg1, T arg2);

    /// <summary>
    /// Formats and writes an trace log message
    /// </summary>
    /// <param name="messageTemplate">Log message template</param>
    /// <param name="args">Arguments</param>
    void LogTrace(string messageTemplate, params object[] args);
}