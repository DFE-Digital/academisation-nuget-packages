namespace Dfe.Academisation.CorrelationIdMiddleware;

/// <summary>
/// Provides access to the current correlation id. You should register this as a scoped / per web request
/// dependency in your IoC/DI container.
/// </summary>
#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs instead.")]
#pragma warning restore S1133
public interface ICorrelationContext
{
    /// <summary>
    /// Returns the current correlation id if it has been set
    /// </summary>
    public Guid CorrelationId { get; }
    
    /// <summary>
    /// Used by the middleware to store the current correlation id. Do not call this method yourself.
    /// </summary>
    /// <param name="correlationId"></param>
    public void SetContext(Guid correlationId);
}