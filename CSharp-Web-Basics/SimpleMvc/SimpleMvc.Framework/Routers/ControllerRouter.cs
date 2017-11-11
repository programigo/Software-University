using SimpleMvc.Framework.Interfaces;

namespace SimpleMvc.Framework.Routers
{
    using Attributes.Methods;
    using Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebServer.Contracts;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;
    using HttpStatusCode = WebServer.Enums.HttpStatusCode;

    public class ControllerRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var getParams = new Dictionary<string, string>(request.UrlParameters);
            var postParams = new Dictionary<string, string>(request.FormData);

            //Retrieving request method
            var requestMethod = request.Method.ToString().ToUpper();

            //Retrieving controller and action names
            var requestUrl = request.Path.Split('/');
            var controllerName = requestUrl[1];
            var actionName = requestUrl[2];

            if (controllerName != null ||
                actionName != null)
            {
                controllerName = controllerName.Replace(controllerName[0], char.ToUpper(controllerName[0]));
                actionName = char.ToUpper(actionName[0]) + actionName.Substring(1);

                controllerName = controllerName + "Controller";
            }

            //Retrieving executing method
            Controller controller = this.GetController(controllerName);

            if (controller != null)
            {
                controller.Request = request;
                controller.InitializeController();
            }

            MethodInfo method = this.GetMethod(controller, requestMethod, actionName);

            if (method == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            var methodParams = this.AddParameters(parameters, getParams, postParams);

            try
            {
                IHttpResponse response = this.GetResponse(method, controller, methodParams);

                return response;
            }
            catch (Exception e)
            {
                return new InternalServerErrorResponse(e);
            }
        }

        private IHttpResponse GetResponse(MethodInfo method, Controller controller, object[] methodParams)
        {
            object actionResult = method.Invoke(controller, methodParams);

            IHttpResponse response = null;

            if (actionResult is IVewable)
            {
                string content = ((IVewable)actionResult).Invoke();

                response = new ContentResponse(HttpStatusCode.Ok, content);
            }
            else if (actionResult is IRedirectable)
            {
                string redirectUrl = ((IRedirectable)actionResult).Invoke();

                response = new RedirectResponse(redirectUrl);
            }

            return response;
        }

        private object[] AddParameters(IEnumerable<ParameterInfo> parameters, Dictionary<string, string> getParams, Dictionary<string, string> postParams)
        {
            object[] methodParams = new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo parameter in parameters)
            {
                if (parameter.ParameterType.IsPrimitive
                    || parameter.ParameterType == typeof(string))
                {
                    methodParams[index] = this.ProcessPrimitiveParameter(parameter, getParams);

                    index++;
                }
                else
                {
                    methodParams[index] = this.ProcessComplexParameter(parameter, postParams);
                }
            }

            return methodParams;
        }

        private object ProcessPrimitiveParameter(ParameterInfo parameter, Dictionary<string, string> getParams)
        {
            object value = getParams[parameter.Name];

            return Convert.ChangeType(value, parameter.ParameterType);
        }

        private object ProcessComplexParameter(ParameterInfo parameter, Dictionary<string, string> postParams)
        {
            Type bindingModelType = parameter.ParameterType;

            object bindingModel = Activator.CreateInstance(bindingModelType);

            IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name], property.PropertyType));
            }

            return Convert.ChangeType(bindingModel, bindingModelType);
        }

        private MethodInfo GetMethod(Controller controller, string requestMethod, string actionName)
        {
            MethodInfo method = null;

            var allMethods = this.GetSuitableMethods(controller, actionName);

            foreach (var methodInfo in allMethods)
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name == actionName);
        }

        private Controller GetController(string controllerName)
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName);

            Type type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }
    }
}