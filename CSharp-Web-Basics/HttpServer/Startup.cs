namespace HttpServer
{
    using System;
    using System.IO;

    public class Startup : IRunnable
    {
        private WebServer webServer;

        public static void Main()
        {
            new Startup().Run();

            string html = File.ReadAllText("index.html");

            Console.WriteLine(html);
        }

        public void Run()
        {
            IApplication app = new ByTheCakeApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            this.webServer = new WebServer(1337, routeConfig);
            this.webServer.Run();
        }
    }
}