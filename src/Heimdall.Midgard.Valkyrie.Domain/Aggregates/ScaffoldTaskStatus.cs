namespace Heimdall.Midgard.Valkyrie.Domain.Aggregates;

public sealed class ScaffoldTaskStatus(int id, string name) : EntityEnumeration(id, name)
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Created = new(1, nameof(Created).ToLowerInvariant());

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Queued = new(2, nameof(Queued).ToLowerInvariant());

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Completed = new(4, nameof(Completed).ToLowerInvariant());

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Failed = new(8, nameof(Failed).ToLowerInvariant());

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Cancelled = new(16, nameof(Cancelled).ToLowerInvariant());

    public static IEnumerable<ScaffoldTaskStatus> List()
    {
        var result = new List<ScaffoldTaskStatus>
        {
            Created,
            Queued,
            Completed,
            Failed,
            Cancelled
        };

        return result.AsEnumerable();
    }
}