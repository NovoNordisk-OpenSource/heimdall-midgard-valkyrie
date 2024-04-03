namespace Heimdall.Midgard.Valkyrie.Application.Telemetry;

public static partial class Logs
{
    [LoggerMessage(LogLevel.Information, "Starting the application with process id: {processId}.")]
    public static partial void LogStarting(this ILogger logger, int processId);

    [LoggerMessage(LogLevel.Information, "ScaffoldTaskReturnCount: `{count}` entities returned to client.")]
    public static partial void LogScaffoldTaskReturnCount(this ILogger logger, int count);

    [LoggerMessage(LogLevel.Information, "LogScaffoldTaskFound: `{id}` match returned to client.")]
    public static partial void LogScaffoldTaskFound(this ILogger logger, Guid? id);

    [LoggerMessage(LogLevel.Information, "LogScaffoldTaskStatusChange: `{id}` `{reason}` and returned to client.")]
    public static partial void LogScaffoldTaskStatusChange(this ILogger logger, Guid? id, string reason);
}