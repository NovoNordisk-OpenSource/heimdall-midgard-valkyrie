namespace Heimdall.Midgard.Valkyrie.Application;

/// <summary>
///     Represents the facade for the application layer of the microservice.
/// </summary>
/// <remarks>
///     The facade design pattern is used to provide a simplified interface to a complex subsystem.
///     In this case, the ApplicationFacade acts as a high-level interface that hides the complexities of the application
///     layer of the microservice.
///     It encapsulates the interactions with the underlying components, such as the MediatR library, and provides a
///     unified and simplified API for the clients to interact with.
///     By using the facade pattern, the application layer becomes more modular, maintainable, and easier to use, as the
///     clients don't need to be aware of the internal details and dependencies of the subsystem.
/// </remarks>
/// <remarks>
///     Initializes a new instance of the <see cref="ApplicationFacade" /> class.
/// </remarks>
/// <param name="mediator">The mediator instance used for handling requests.</param>
public sealed class ApplicationFacade(IMediator mediator) : Facade(mediator), IApplicationFacade
{
}