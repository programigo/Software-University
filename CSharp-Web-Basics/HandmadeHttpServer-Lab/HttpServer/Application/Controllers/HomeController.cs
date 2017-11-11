public class HomeController
{
    public IHttpResponse Index()
    {
        return new ViewResponse(HttpStatusCode.Ok, new HomeIndexView());
    }
}