using System;

public abstract class RequestHandler : IRequestHandler
{
    private readonly Func<IHttpRequest, IHttpResponse> func;

    public RequestHandler(Func<IHttpRequest, IHttpResponse> func)
    {
        this.func = func;
    }

    public IHttpResponse Handle(IHttpContext httpContext)
    {
        var httpResponse = this.func(httpContext.Request);

        httpResponse.Headers.Add(new HttpHeader("Content-Type", "text/html"));

        return httpResponse;
    }
}