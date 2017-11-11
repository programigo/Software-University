public interface IHttpResponse
{
    HttpStatusCode StatusCode { get; }

    HttpHeaderCollection Headers { get; }

    string Response { get; }
}