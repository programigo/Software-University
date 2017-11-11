namespace _07.BoundedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] boundaries =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int lowerBound = boundaries.Min();
            int upperBound = boundaries.Max();

            List<int> numbers =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            var filteredNums = numbers.Where(num => num >= lowerBound && num <= upperBound);

            Console.WriteLine(string.Join(" ", filteredNums));
        }
    }
}