namespace Heimdall.Midgard.Valkyrie.Domain;

/// <summary>
///     Represents an exception that is thrown by the domain.
/// </summary>
public sealed class DomainException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainException" /> class.
    /// </summary>
    public DomainException()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public DomainException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainException" /> class with a specified error message
    ///     and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception, or a null reference if no inner
    ///     exception is specified.
    /// </param>
    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
    }
}