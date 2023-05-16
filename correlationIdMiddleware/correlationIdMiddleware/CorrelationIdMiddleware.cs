using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Dfe.Academisation.CorrelationIdMiddleware;

/// <summary>
/// Middleware that checks incoming requests for a correlation and causation id header. If not found then default values will be created.
/// Saves these values in the correlationContext instance. Be sure to register correlation context as scoped or the equivalent in you ioc container.
/// Header used in requests is 'x-correlation-id'
/// </summary>
public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;

    public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = Guard.Against.Null(logger);
    }

    // ReSharper disable once UnusedMember.Global
    // Invoked by asp.net
    public Task Invoke(HttpContext httpContext, ICorrelationContext correlationContext)
    {
        string thisCorrelationId;

        // correlation id. An ID that spans many requests
        if (httpContext.Request.Headers.ContainsKey(correlationContext.HeaderKey) &&
            !string.IsNullOrWhiteSpace(httpContext.Request.Headers[correlationContext.HeaderKey]))
        {
            thisCorrelationId = httpContext.Request.Headers[correlationContext.HeaderKey];
            _logger.LogInformation("CorrelationId detected from header: {correlationId}", thisCorrelationId);
        }
        else
        {
            thisCorrelationId = Guid.NewGuid().ToString();
            _logger.LogInformation("CorrelationId not detected from headers. Generated a new one: {correlationId}",
                thisCorrelationId);
        }

        httpContext.Request.Headers[correlationContext.HeaderKey] = thisCorrelationId;

        correlationContext.SetContext(thisCorrelationId);

        httpContext.Response.Headers[correlationContext.HeaderKey] = thisCorrelationId;
        return _next(httpContext);
    }
}