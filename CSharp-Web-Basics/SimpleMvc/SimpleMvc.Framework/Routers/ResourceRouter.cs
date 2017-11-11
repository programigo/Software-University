using System;
using System.IO;
using System.Linq;
using WebServer.Contracts;
using WebServer.Http.Contracts;
using WebServer.Http.Response;
using HttpStatusCode = WebServer.Enums.HttpStatusCode;

namespace SimpleMvc.Framework.Routers
{
    public class ResourceRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            string fileFulName = request.Path.Split("/").Last();
            string fileExtension = request.Path.Split(".").Last();

            IHttpResponse fileResponse = null;

            try
            {
                byte[] fileContent = this.ReadFileContent(fileFulName, fileExtension);

                fileResponse = new FileResponse(HttpStatusCode.Found, fileContent);
            }
            catch (Exception e)
            {
                return new NotFoundResponse();
            }

            return fileResponse;
        }

        private byte[] ReadFileContent(string fileFulName, string fileExtension)
        {
            byte[] byteContent = File.ReadAllBytes(string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ResourcesFolder,
                fileExtension,
                fileFulName));

            return byteContent;
        }
    }
}