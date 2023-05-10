namespace TodoApp.Api.Brokers.Logger;

/// <summary>
/// Represents logger broker
/// </summary>
public class LoggerBroker : ILoggerBroker
{
    private readonly ILogger<LoggerBroker> _logger;

    public LoggerBroker(ILogger<LoggerBroker> logger)
    {
        _logger = logger;
    }

    public void LogCritical<T>(string messageTemplate, T arg0)
    {
        if (!_logger.IsEnabled(LogLevel.Critical))
            return;

        _logger.LogCritical(messageTemplate, arg0);
    }

    public void LogCritical<T>(string messageTemplate, T arg0, T arg1)
    {
        if (!_logger.IsEnabled(LogLevel.Critical))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1);
    }

    public void LogCritical<T>(string messageTemplate, T arg0, T arg1, T arg2)
    {
        if (!_logger.IsEnabled(LogLevel.Critical))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1, arg2);
    }

    public void LogCritical(string messageTemplate, params object[] args)
    {
        if (!_logger.IsEnabled(LogLevel.Critical))
            return;

        _logger.LogCritical(messageTemplate, args);
    }

    public void LogError<T>(string messageTemplate, T arg0)
    {
        if (!_logger.IsEnabled(LogLevel.Error))
            return;

        _logger.LogError(messageTemplate, arg0);
    }

    public void LogError<T>(string messageTemplate, T arg0, T arg1)
    {
        if (!_logger.IsEnabled(LogLevel.Error))
            return;

        _logger.LogError(messageTemplate, arg0, arg1);
    }

    public void LogError<T>(string messageTemplate, T arg0, T arg1, T arg2)
    {
        if (!_logger.IsEnabled(LogLevel.Error))
            return;

        _logger.LogError(messageTemplate, arg0, arg1, arg2);
    }

    public void LogError(string messageTemplate, params object[] args)
    {
        if (!_logger.IsEnabled(LogLevel.Error))
            return;

        _logger.LogError(messageTemplate, args);
    }

    public void LogWarning<T>(string messageTemplate, T arg0)
    {
        if (!_logger.IsEnabled(LogLevel.Warning))
            return;

        _logger.LogCritical(messageTemplate, arg0);
    }

    public void LogWarning<T>(string messageTemplate, T arg0, T arg1)
    {
        if (!_logger.IsEnabled(LogLevel.Warning))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1);
    }

    public void LogWarning<T>(string messageTemplate, T arg0, T arg1, T arg2)
    {
        if (!_logger.IsEnabled(LogLevel.Warning))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1, arg2);
    }

    public void LogWarning(string messageTemplate, params object[] args)
    {
        if (!_logger.IsEnabled(LogLevel.Warning))
            return;

        _logger.LogCritical(messageTemplate, args);
    }

    public void LogInformation<T>(string messageTemplate, T arg0)
    {
        if (!_logger.IsEnabled(LogLevel.Information))
            return;

        _logger.LogCritical(messageTemplate, arg0);
    }

    public void LogInformation<T>(string messageTemplate, T arg0, T arg1)
    {
        if (!_logger.IsEnabled(LogLevel.Information))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1);
    }

    public void LogInformation<T>(string messageTemplate, T arg0, T arg1, T arg2)
    {
        if (!_logger.IsEnabled(LogLevel.Information))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1, arg2);
    }

    public void LogInformation(string messageTemplate, params object[] args)
    {
        if (!_logger.IsEnabled(LogLevel.Information))
            return;

        _logger.LogCritical(messageTemplate, args);
    }

    public void LogDebug<T>(string messageTemplate, T arg0)
    {
        if (!_logger.IsEnabled(LogLevel.Debug))
            return;

        _logger.LogCritical(messageTemplate, arg0);
    }

    public void LogDebug<T>(string messageTemplate, T arg0, T arg1)
    {
        if (!_logger.IsEnabled(LogLevel.Debug))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1);
    }

    public void LogDebug<T>(string messageTemplate, T arg0, T arg1, T arg2)
    {
        if (!_logger.IsEnabled(LogLevel.Debug))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1, arg2);
    }

    public void LogDebug(string messageTemplate, params object[] args)
    {
        if (!_logger.IsEnabled(LogLevel.Debug))
            return;

        _logger.LogCritical(messageTemplate, args);
    }

    public void LogTrace<T>(string messageTemplate, T arg0)
    {
        if (!_logger.IsEnabled(LogLevel.Trace))
            return;

        _logger.LogCritical(messageTemplate, arg0);
    }

    public void LogTrace<T>(string messageTemplate, T arg0, T arg1)
    {
        if (!_logger.IsEnabled(LogLevel.Trace))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1);
    }

    public void LogTrace<T>(string messageTemplate, T arg0, T arg1, T arg2)
    {
        if (!_logger.IsEnabled(LogLevel.Trace))
            return;

        _logger.LogCritical(messageTemplate, arg0, arg1, arg2);
    }

    public void LogTrace(string messageTemplate, params object[] args)
    {
        if (!_logger.IsEnabled(LogLevel.Trace))
            return;

        _logger.LogCritical(messageTemplate, args);
    }
}