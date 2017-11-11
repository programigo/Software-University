﻿public class MainApplication : IApplication
{
    public void Start(IAppRouteConfig appRouteConfig)
    {
        appRouteConfig.Get(
            "/",
            req => new HomeController().Index());

        appRouteConfig.Get(
            "/testsession",
            req => new HomeController().SessionTest(req));

        appRouteConfig.Get(
            "/users/{(?<name>[a-z]+)}",
            req => new HomeController().Index());
    }
}