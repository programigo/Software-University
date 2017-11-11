public class ViewResponse : HttpResponse
{
    public ViewResponse(HttpStatusCode responseCode, IView view) : base(responseCode, view)
    {
    }
}