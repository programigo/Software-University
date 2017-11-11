namespace _02.ParseURLs
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string url = Console.ReadLine();
            string[] elements = url.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if (url.IndexOf("/") == -1 || elements.Length != 2)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                string protocol = elements[0];
                int dashIndex = elements[1].IndexOf("/");
                if (dashIndex == -1)
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }
                string server = elements[1].Substring(0, dashIndex);
                string resources = elements[1].Substring(dashIndex + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}