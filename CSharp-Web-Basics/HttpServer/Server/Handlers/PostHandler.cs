using System;

public class PostHandler : RequestHandler
{
    public PostHandler(Func<IHttpRequest, IHttpResponse> func) : base(func)
    {
    }
}