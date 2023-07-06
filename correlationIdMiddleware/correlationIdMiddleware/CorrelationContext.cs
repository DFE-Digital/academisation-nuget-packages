namespace Dfe.Academisation.CorrelationIdMiddleware;

/// <inheritdoc />
public class CorrelationContext : ICorrelationContext
{
    /// <inheritdoc />
    public string? CorrelationId { get; private set; }

    /// <inheritdoc />
    public void SetContext(string correlationId)
    {
        if (string.IsNullOrWhiteSpace(correlationId))
        {
            throw new ArgumentNullException(nameof(correlationId));
        }
        this.CorrelationId = correlationId;
    }
}