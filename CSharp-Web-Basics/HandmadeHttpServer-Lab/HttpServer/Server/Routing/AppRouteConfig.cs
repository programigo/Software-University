using System;
using System.Collections.Generic;
using System.Linq;

public class AppRouteConfig : IAppRouteConfig
{
    private readonly Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> routes;

    public AppRouteConfig()
    {
        this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>>();

        foreach (var httpRequestMethod in Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>())
        {
            this.routes.Add(httpRequestMethod, new Dictionary<string, RequestHandler>());
        }
    }

    public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes => this.routes;

    public void AddRoute(string route, RequestHandler httpHandler)
    {
        if (httpHandler.GetType().ToString().ToLower().Contains("get"))
        {
            this.routes[HttpRequestMethod.GET].Add(route, httpHandler);
        }
        else if (httpHandler.GetType().ToString().ToLower().Contains("post"))
        {
            this.routes[HttpRequestMethod.POST].Add(route, httpHandler);
        }
    }
}