namespace WebServer.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
        }

        private const string InvalidRequestMessage = "Request is not valid.";

        public static object ThrowFromInvalidRequest()
            => throw new BadRequestException(InvalidRequestMessage);
    }
}