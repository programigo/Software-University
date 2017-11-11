using System.Text.RegularExpressions;

public class HttpHandler : IRequestHandler
{
    private readonly IServerRouteConfig serverRouteConfig;

    public HttpHandler(IServerRouteConfig serverRouteConfig)
    {
        this.serverRouteConfig = serverRouteConfig;
    }

    public IHttpResponse Handle(IHttpContext httpContext)
    {
        var requestMethod = httpContext.Request.RequestMethod;
        var requestPath = httpContext.Request.Path;
        var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

        foreach (var registeredRoute in registeredRoutes)
        {
            var routePattern = registeredRoute.Key;
            var routingContext = registeredRoute.Value;

            var routeRegex = new Regex(routePattern);
            var match = routeRegex.Match(requestPath);

            if (!match.Success)
            {
                continue;
            }

            var parameters = routingContext.Parameters;

            foreach (var parameter in parameters)
            {
                var parameterValue = match.Groups[parameter].Value;
                httpContext.Request.AddUrlParameter(parameter, parameterValue);
            }

            return routingContext.RequestHandler.Handle(httpContext);
        }

        return new NotFoundResponse();
    }
}