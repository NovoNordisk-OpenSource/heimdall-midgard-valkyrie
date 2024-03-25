namespace Heimdall.Midgard.Valkyrie.Application.Mapping.Converters;

public class IAggregateRootToICommandConverter : ITypeConverter<IAggregateRoot, ICommand<IAggregateRoot>>
{
    /// <summary>
    /// Converts an <see cref="IAggregateRoot"/> object to an <see cref="ICommand{IAggregateRoot}"/> object.
    /// </summary>
    /// <param name="source">The source <see cref="IAggregateRoot"/> object to convert.</param>
    /// <param name="destination">The destination <see cref="ICommand{IAggregateRoot}"/> object.</param>
    /// <param name="context">The resolution context.</param>
    /// <returns>The converted <see cref="ICommand{IAggregateRoot}"/> object.</returns>
    public ICommand<IAggregateRoot> Convert(IAggregateRoot source, ICommand<IAggregateRoot> destination, ResolutionContext context)
    {
        switch (source)
        {
            case ScaffoldTask entity:
                if (entity.Id == Guid.Empty)
                {
                    destination = new CreateScaffoldTaskCommand(entity.Options);
                }
                else
                {
                    destination = new UpdateScaffoldTaskCommand(entity);
                }

                break;
            case null:
            default:
                throw new NotSupportedException($"The aggregate root type {source?.GetType().Name} is not supported.");
        }

        return destination;
    }
}