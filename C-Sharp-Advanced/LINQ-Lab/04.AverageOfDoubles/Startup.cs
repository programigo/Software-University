namespace _04.AverageOfDoubles
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

            var average = numbers.Average();

            Console.WriteLine($"{average:f2}");
        }
    }
}
