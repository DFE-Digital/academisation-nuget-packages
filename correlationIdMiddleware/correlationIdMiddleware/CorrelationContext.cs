namespace Dfe.Academisation.CorrelationIdMiddleware;

/// <inheritdoc />
#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs/pkgs/nuget/DfE.CoreLibs.Http instead.")]
#pragma warning restore S1133
public class CorrelationContext : ICorrelationContext
{
    /// <inheritdoc />
    public Guid CorrelationId { get; private set; }

    /// <inheritdoc />
    public void SetContext(Guid correlationId)
    {
        if (correlationId == Guid.Empty)
        {
            throw new ArgumentException("Guid cannot be empty", nameof(correlationId));
        }
        this.CorrelationId = correlationId;
    }
}