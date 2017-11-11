using System.Collections.Generic;

public class RoutingContext : IRoutingContext
{
    private readonly List<string> parameters;

    public RoutingContext(RequestHandler requestHandler, List<string> parameters)
    {
        this.RequestHandler = requestHandler;
        this.parameters = parameters;
    }

    public IEnumerable<string> Parameters => this.parameters;

    public RequestHandler RequestHandler { get; }
}