using System.Collections.Generic;

public interface IAppRouteConfig
{
    IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

    void AddRoute(string route, RequestHandler httpHandler);
}