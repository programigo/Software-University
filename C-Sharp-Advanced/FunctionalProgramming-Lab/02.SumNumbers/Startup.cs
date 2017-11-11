namespace _02.SumNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var collection = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            Console.WriteLine(collection.Count());

            Console.WriteLine(collection.Sum());
        }
    }
}
