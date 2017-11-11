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

    public void Get(string route, Func<IHttpRequest, IHttpResponse> handler)
    {
        this.AddRoute(route, HttpRequestMethod.GET, new RequestHandler(handler));
    }

    public void Post(string route, Func<IHttpRequest, IHttpResponse> handler)
    {
        this.AddRoute(route, HttpRequestMethod.POST, new RequestHandler(handler));
    }

    public void AddRoute(string route, HttpRequestMethod method, RequestHandler handler)
    {
        this.routes[method].Add(route, handler);
    }
}