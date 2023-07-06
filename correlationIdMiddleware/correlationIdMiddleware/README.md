# Correlation ID Middleware

## What does this do ?

This package contains middleware that you can register in your AspNet application to enable detection of `x-correlationId` request headers that can then be propagated and use in logging, further requests, and responses.

## Why does it do it ?

CorrelationIds that are passed between services and recorded in all logs help to dramatically reduce the complexity involved in debugging applications, particularly where multiple services are involved.

## How to use it 

* Reference the Nuget package.

* In your application start-up, register the correlation context as a scoped dependency. For example
`services.AddScoped<ICorrelationContext, CorrelationContext>();`

* Add the CorrelationId middleware to your AspNet middleware pipeline. You should add this as early as possible so that correlationIds can be logged.
`app.UseMiddleware<CorrelationIdMiddleware>();`

* Anywhere that you need access to the current correlation id, inject `ICorrelationContext` and access the current context using the `CorrelationId` property. It will return a `string?` that you can use in subsequent requests or wherever you need it.

---

## Default AspNet Logger
The middleware will add the current correlation id as scoped data before calling the next middleware in the AspNet middleware pipeline.
If you are using the default AspNet logger, to see this in your log output you need to enable scopes in the output.
One simple way of doing this is to use the console output by adding the following to your logger configuration.
Alternatively use something like Seq to view logs locally.

```json
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Information",
      "Microsoft.Hosting.Lifetime": "Information",
      "Microsoft.AspNetCore": "Warning"
    },
    "Console": {
      "FormatterName": "simple",
      "FormatterOptions": {
        "IncludeScopes": "true"
      }
    }
  },
```

## Not using the default AspNet Logger ?
The middleware will push an `x-correlationId` scope property onto the default Microsoft logging implementation.

If you are using another logger, create a middleware and register it as the next one in the pipeline after the `CorrelationIdMiddleware`. Inject the `ICorrelationContext` into your middleware and use the `ICorrelationContext.CorrelationId` property to access the correlationId value and include it in your own logs. For example Serilog.
