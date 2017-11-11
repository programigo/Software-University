namespace _01.SortEvenNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray()
                .Where(num => num % 2 == 0)
                .OrderBy(n => n)));
        }
    }
}
