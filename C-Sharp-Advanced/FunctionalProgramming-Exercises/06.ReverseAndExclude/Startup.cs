namespace _06.ReverseAndExclude
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
                    .Reverse()
                    .ToList();

            int divisor = int.Parse(Console.ReadLine());

            numbers.RemoveAll(num => num % divisor == 0);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
