public class NotFoundResponse : HttpResponse
{
    public NotFoundResponse()
    {
        this.View = new NotFoundView();
        this.StatusCode = HttpStatusCode.NotFound;
    }
}