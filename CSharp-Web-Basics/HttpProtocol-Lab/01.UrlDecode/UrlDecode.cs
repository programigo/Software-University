namespace _01.UrlDecode
{
    using System;
    using System.Net;

    public class UrlDecode
    {
        public static void Main()
        {
            string url = WebUtility.UrlDecode(Console.ReadLine());

            Console.WriteLine(url);
        }
    }
}
