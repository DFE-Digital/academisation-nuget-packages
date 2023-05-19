# Correlation ID Middleware

## What does this do ?
This package will add middleware to your ASP.Net application that looks a correlation-id header in the request headers, and then makes the correlation id available for use throughout your application, where it can be used for things such as logging and making futher http requests.
## Why does it do it ?
Using a correlation id that is the same throughout the lifetime of an http request makes debugging much easier. Including that correlation id in http requests you make to other services, and those services using it in their logs and their http requests allows one consolidated view of a user journey in tools such as Kibana.

## How to use it 

1) Install the package.

2) Add the middleware to your startup configuration
```  
    app.UseMiddleware<CorrelationIdMiddleware>();
```
3) Register the CorrelationContext from the pacakge with your dependecy injection framework. **Important, you must use a lifestyle that will be scoped to the lifetime of a http request**
```   
    services.AddScoped<ICorrelationContext, CorrelationContext>();
```
4) Inject `ICorrelationContext` wherever you need access to the correlation id. For example to include the correlation id on outgoing requests you could do something similar to the example snippet below.
```
	public class MyServiceClient
	{
		private readonly ICorrelationContext _correlationContext;
		private readonly IHttpClientFactory _clientFactory;

		protected AbstractService(IHttpClientFactory clientFactory, ICorrelationContext correlationContext)
		{
			_clientFactory = clientFactory;
			_correlationContext = correlationContext;
		}

		public HttpClient CreateHttpClient()
		{
			var client = _clientFactory.CreateClient(HttpClientName);

			client.DefaultRequestHeaders.TryAddWithoutValidation(correlationContext.HeaderKey, correlationContext.CorrelationId);

			return client;
		}
    }
``` 