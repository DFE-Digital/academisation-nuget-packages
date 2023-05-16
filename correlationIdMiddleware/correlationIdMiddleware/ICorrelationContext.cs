namespace Dfe.Academisation.CorrelationIdMiddleware;

public interface ICorrelationContext
{
    public string? CorrelationId { get; }
    public void SetContext(string correlationId);
    public string HeaderKey { get; }
}