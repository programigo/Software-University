namespace SimpleMvc.App
{
    using Framework;
    using Framework.Routers;
    using WebServer = WebServer.WebServer;

    public class Launcher
    {
        public static void Main()
        {
            var server = new WebServer(8000, new ControllerRouter(), new ResourceRouter());

            MvcEngine.Run(server);
        }
    }
}