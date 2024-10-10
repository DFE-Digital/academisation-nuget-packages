namespace Dfe.Academisation.CorrelationIdMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

/// <summary>
/// Middleware that checks incoming requests for a correlation and causation id header. If not found then default values will be created.
/// Saves these values in the correlationContext instance. Be sure to register correlation context as scoped or the equivalent in you ioc container.
/// Header used in requests is 'x-correlationId'
/// </summary>
#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs/pkgs/nuget/DfE.CoreLibs.Http instead.")]
#pragma warning restore S1133
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
        Guid thisCorrelationId;

        // correlation id. An ID that spans many requests
        if (httpContext.Request.Headers.ContainsKey(Keys.HeaderKey) 
            && !string.IsNullOrWhiteSpace(httpContext.Request.Headers[Keys.HeaderKey]))
        {
            if (!Guid.TryParse(httpContext.Request.Headers[Keys.HeaderKey], out thisCorrelationId))
            {
                thisCorrelationId = Guid.NewGuid();
                this._logger.LogWarning("Detected header x-correlationId, but value cannot be parsed to a GUID. Other values are not supported. Generated a new one: {correlationId}", thisCorrelationId);
            }
            else
            {
                _logger.LogInformation("CorrelationIdMiddleware:Invoke - x-correlationId detected in request headers: {correlationId}", thisCorrelationId);
            }
        }
        else
        {
            thisCorrelationId = Guid.NewGuid();
            _logger.LogWarning("CorrelationIdMiddleware:Invoke - x-correlationId not detected in request headers. Generated a new one: {correlationId}", thisCorrelationId);
        }

        if (thisCorrelationId == Guid.Empty)
        {
            var result = new
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = $"Bad Request. {Keys.HeaderKey} header cannot be an empty GUID"
            };


            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            httpContext.Response.ContentType = "text/json";
            return httpContext.Response.WriteAsync(result.ToString());
        }


        httpContext.Request.Headers[Keys.HeaderKey] = thisCorrelationId.ToString();

        correlationContext.SetContext(thisCorrelationId);

        httpContext.Response.Headers[Keys.HeaderKey] = thisCorrelationId.ToString();
        using (_logger.BeginScope("x-correlationId: {x-correlationId}", correlationContext.CorrelationId.ToString()))
        {
            return _next(httpContext);
        }
    }
}