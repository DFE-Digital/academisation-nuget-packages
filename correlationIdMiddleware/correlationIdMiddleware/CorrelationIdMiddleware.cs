namespace Dfe.Academisation.CorrelationIdMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

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
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    // ReSharper disable once UnusedMember.Global
    // Invoked by asp.net
    public Task Invoke(HttpContext httpContext, ICorrelationContext correlationContext)
    {
        string thisCorrelationId;

        // correlation id. An ID that spans many requests
        if (httpContext.Request.Headers.ContainsKey(Keys.HeaderKey) &&
            !string.IsNullOrWhiteSpace(httpContext.Request.Headers[Keys.HeaderKey]))
        {
            thisCorrelationId = httpContext.Request.Headers[Keys.HeaderKey];
            _logger.LogInformation("CorrelationIdMiddleware:Invoke - x-correlationId detected in request headers: {correlationId}", thisCorrelationId);
        }
        else
        {
            thisCorrelationId = Guid.NewGuid().ToString();
            _logger.LogInformation("CorrelationIdMiddleware:Invoke - x-correlationId not detected in request headers. Generated a new one: {correlationId}",
                thisCorrelationId);
        }

        httpContext.Request.Headers[Keys.HeaderKey] = thisCorrelationId;

        correlationContext.SetContext(thisCorrelationId);

        httpContext.Response.Headers[Keys.HeaderKey] = thisCorrelationId;
        using (_logger.BeginScope("x-correlationId {x-correlationId}", correlationContext.CorrelationId))
        {
            return _next(httpContext);
        }
    }
}