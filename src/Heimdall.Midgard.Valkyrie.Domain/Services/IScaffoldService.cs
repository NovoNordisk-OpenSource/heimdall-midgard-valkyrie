using BeHeroes.CodeOps.Abstractions.Services;

namespace Heimdall.Midgard.Valkyrie.Domain.Services;

/// <summary>
///     Represents a domain service that provides scaffolding operations.
/// </summary>
public interface IScaffoldService : IService
{
    /// <summary>
    ///     Retrieves all scaffold tasks.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of scaffolde tasks.</returns>
    Task<IEnumerable<ScaffoldTask>> GetScaffoldTasksAsync(CancellationToken ct = default);

    /// <summary>
    ///     Retrieves scaffold task by GUID.
    /// </summary>
    /// <param name="scaffoldTaskId">The entity GUID.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation which contains the matched scaffold task.</returns>
    Task<ScaffoldTask?> GetScaffoldTaskByIdAsync(Guid scaffoldTaskId, CancellationToken ct = default);

    /// <summary>
    ///     Retrieves scaffold tasks by date range.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of scaffolde tasks.</returns>
    Task<IEnumerable<ScaffoldTask>> GetScaffoldTaskByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default);

    /// <summary>
    ///     Adds a new scaffold task.
    /// </summary>
    /// <param name="options">The collection of scaffold options to be associated with the scaffold task.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added scaffold task.</returns>
    Task<ScaffoldTask> AddScaffoldTaskAsync(AccountInfo account, IEnumerable<ScaffoldOption>? options = default, CancellationToken ct = default);

    /// <summary>
    ///     Updates an existing scaffold task.
    /// </summary>
    /// <param name="entity">The scaffold task to be updated.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated scaffold task.</returns>
    Task<ScaffoldTask> UpdateScaffoldTaskAsync(ScaffoldTask entity, CancellationToken ct = default);

    /// <summary>
    ///     Deletes a scaffold task by its identifier.
    /// </summary>
    /// <param name="scaffoldTaskId">The identifier of the scaffold task to be deleted.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result indicates whether the deletion was
    ///     successful.
    /// </returns>
    Task<bool> DeleteScaffoldTaskAsync(Guid scaffoldTaskId, CancellationToken ct = default);

    /// <summary>
    ///     Adds or updates a scaffold option associated with a scaffold task.
    /// </summary>
    /// <param name="scaffoldTaskId">The identifier of the scaffold task.</param>
    /// <param name="key">The key of the scaffold option.</param>
    /// <param name="value">The value of the scaffold option.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the added or updated domain
    ///     object.entityId
    /// </returns>
    Task<ScaffoldOption> AddOrUpdateScaffoldOptionAsync(Guid scaffoldTaskId, string key, string value, CancellationToken ct = default);

    /// <summary>
    ///     Deletes a scaffold option associated with a scaffold task.
    /// </summary>
    /// <param name="scaffoldTaskId">The identifier of the scaffold task.</param>
    /// <param name="key">The key of the scaffold option.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result indicates whether the deletion was
    ///     successful.
    /// </returns>
    Task<bool> DeleteScaffoldOptionAsync(Guid scaffoldTaskId, string key, CancellationToken ct = default);
}