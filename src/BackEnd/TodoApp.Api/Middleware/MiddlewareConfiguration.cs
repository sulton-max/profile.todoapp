using Serilog;

namespace TodoApp.Api.Middleware;

public static class MiddlewareConfiguration
{
    public static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

        builder.Logging.ClearProviders();
        builder.Host.UseSerilog(logger);

        return builder;
    }
}