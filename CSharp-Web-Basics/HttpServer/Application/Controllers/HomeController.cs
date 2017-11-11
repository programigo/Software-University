public class CakeHomeControllere
{
    public IHttpResponse Index()
    {
        return new ViewResponse(HttpStatusCode.Ok, new HomeIndexView());
    }
}