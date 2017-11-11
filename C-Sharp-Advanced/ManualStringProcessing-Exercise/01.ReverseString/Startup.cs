namespace _01.ReverseString
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToCharArray();

            Array.Reverse(text);

            Console.WriteLine(text);
        }
    }
}
