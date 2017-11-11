namespace _05.MinEvenNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<double> numbers =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

            var minEven = numbers.Where(num => num % 2 == 0);

            if (minEven.Count() == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine($"{minEven.Min():f2}");
            }
        }
    }
}
