namespace HttpServer
{
    public class Startup : IRunnable
    {
        private WebServer webServer;

        public static void Main()
        {
            new Startup().Run();
        }

        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            this.webServer = new WebServer(1337, routeConfig);
            this.webServer.Run();
        }
    }
}