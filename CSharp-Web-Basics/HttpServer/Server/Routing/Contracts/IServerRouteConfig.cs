using System.Collections.Generic;

public interface IServerRouteConfig
{
    Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
}