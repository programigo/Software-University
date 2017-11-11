public class ByTheCakeApplication : IApplication
{
    public void Start(IAppRouteConfig appRouteConfig)
    {
        appRouteConfig
        .Get("/", req => new HomeController().Index());

        appRouteConfig
            .Get("/about", req => new HomeController().About());

        appRouteConfig
            .Get("/add", req => new CakesController().Add());

        appRouteConfig
            .Post("/add", req => new CakesController().Add(req.FormData["name"], req.FormData["price"]));

        appRouteConfig
            .Get("/search", req => new CakesController().Search(req.UrlParameters));

        appRouteConfig
            .Get("/calculator", req => new HomeController().Calculate());

        appRouteConfig
            .Post("/calculator", req => new HomeController().Calculate(req.FormData["firstNumber"], req.FormData["operaionSign"], req.FormData["secondNumber"]));

        appRouteConfig
            .Get("/login", req => new HomeController().Login());

        appRouteConfig
            .Post("/login", req => new HomeController().Login(req.FormData["username"], req.FormData["password"]));
    }
}