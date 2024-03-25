namespace Heimdall.Midgard.Valkyrie.Domain.Repositories;

/// <summary>
///     Represents a repository for managing <see cref="ScaffoldTask" /> objects.
/// </summary>
public interface IScaffoldTaskRepository : IRepository<ScaffoldTask>
{
    /// <summary>
    ///     Retrieves a <see cref="ScaffoldTask" /> object asynchronously based on its ID.
    /// </summary>
    /// <param name="entityId">The ID of the entity to retrieve.</param>
    /// <param name="ct">The cancellation token (optional).</param>
    /// <returns>
    ///     A task representing the asynchronous operation that returns the retrieved <see cref="ScaffoldTask" /> object,
    ///     or null if not found.
    /// </returns>
    Task<ScaffoldTask?> GetAsync(Guid entityId, CancellationToken ct = default);
}