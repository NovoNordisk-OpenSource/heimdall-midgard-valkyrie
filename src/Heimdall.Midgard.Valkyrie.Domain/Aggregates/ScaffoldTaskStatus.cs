namespace Heimdall.Midgard.Valkyrie.Domain.Aggregates;

public sealed class ScaffoldTaskStatus : EntityEnumeration
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Created = new(1, nameof(Created).ToLowerInvariant());

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Queued = new(2, nameof(Queued).ToLowerInvariant());

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Succeeded = new(4, nameof(Succeeded).ToLowerInvariant());

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Failed = new(8, nameof(Failed).ToLowerInvariant());

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
    public static ScaffoldTaskStatus Cancelled = new(16, nameof(Cancelled).ToLowerInvariant());

    public ScaffoldTaskStatus(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<ScaffoldTaskStatus> List()
    {
        var result = new List<ScaffoldTaskStatus>
        {
            Created,
            Queued,
            Succeeded,
            Failed,
            Cancelled
        };

        return result.AsEnumerable();
    }
}