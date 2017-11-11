namespace _01.TakeTwo
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

            var validNums = numbers.Where(num => num >= 10 && num <= 20).Distinct().Take(2);

            Console.WriteLine(string.Join(" ", validNums));
        }
    }
}
