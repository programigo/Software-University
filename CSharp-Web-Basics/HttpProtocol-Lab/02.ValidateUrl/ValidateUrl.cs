namespace _02.ValidateUrl
{
    using System;
    using System.Net;

    public class ValidateUrl
    {
        public static void Main()
        {
            string url = WebUtility.UrlDecode(Console.ReadLine());

            try
            {
                var urlParts = new Uri(url);

                if (string.IsNullOrEmpty(urlParts.Scheme) || 
                    string.IsNullOrEmpty(urlParts.Host) || 
                    string.IsNullOrEmpty(urlParts.AbsolutePath))
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }

                int port = urlParts.Port;


                if (urlParts.Scheme == "http" && port == 443 ||
                    urlParts.Scheme == "https" && port == 80)
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }

                
                Console.WriteLine($"Protocol: {urlParts.Scheme}");
                Console.WriteLine($"Host: {urlParts.Host}");
                Console.WriteLine($"Port: {port}");
                Console.WriteLine($"Path: {urlParts.AbsolutePath}");

                if (!string.IsNullOrEmpty(urlParts.Query))
                {
                    Console.WriteLine($"Query: {urlParts.Query.Replace("?", "")}");
                }

                if (!string.IsNullOrEmpty(urlParts.Fragment))
                {
                    Console.WriteLine($"Fragment: {urlParts.Fragment.Replace("#", "")}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid URL");
            }         
        }
    }
}
