namespace _08.CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<int> numbers =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            var sortedEven = numbers.Where(n => n % 2 == 0).OrderBy(n => n);
            var sortedOdd = numbers.Where(n => n % 2 != 0).OrderBy(n => n);

            Console.Write(string.Join(" ", sortedEven));
            Console.WriteLine($" {string.Join(" ", sortedOdd)}");
        }
    }
}
