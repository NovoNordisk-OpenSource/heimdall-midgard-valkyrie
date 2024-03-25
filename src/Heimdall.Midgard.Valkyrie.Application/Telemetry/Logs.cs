namespace Heimdall.Midgard.Valkyrie.Application.Telemetry;

public static partial class Logs
{
    [LoggerMessage(LogLevel.Information, "Starting the application with process id: {processId}.")]
    public static partial void LogStarting(this ILogger logger, int processId);

    [LoggerMessage(LogLevel.Information, "ScaffoldTaskReturnCount: `{count}` entities returned to client.")]
    public static partial void LogScaffoldTaskReturnCount(this ILogger logger, int count);
}