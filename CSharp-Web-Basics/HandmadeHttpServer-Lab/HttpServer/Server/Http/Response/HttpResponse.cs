using System.Text;

public abstract class HttpResponse : IHttpResponse
{
    private readonly IView view;

    private string statusMessage => this.StatusCode.ToString();

    protected HttpResponse()
    {
        this.Headers = new HttpHeaderCollection();
    }

    protected HttpResponse(string redirectUrl)
        : this()
    {
        this.StatusCode = HttpStatusCode.Found;
        this.Headers.Add(new HttpHeader("Location", redirectUrl));
    }

    protected HttpResponse(HttpStatusCode responseCode, IView view)
        : this()
    {
        this.View = view;
        this.StatusCode = responseCode;
    }

    public HttpHeaderCollection Headers { get; }

    public HttpStatusCode StatusCode { get; protected set; }

    public IView View { get; set; }

    public string Response
    {
        get
        {
            StringBuilder response = new StringBuilder();

            response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.statusMessage}");

            response.AppendLine(this.Headers.ToString());
            response.AppendLine();

            if ((int)this.StatusCode < 300 || (int)this.StatusCode > 400)
            {
                response.AppendLine(this.View.View());
            }

            return response.ToString();
        }
    }
}