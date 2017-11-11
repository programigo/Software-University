namespace _03.GroupNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers =
                Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var zeros = numbers.Where(number => Math.Abs(number % 3) == 0);
            var ones = numbers.Where(number => Math.Abs(number % 3) == 1);
            var twos = numbers.Where(number => Math.Abs(number % 3) == 2);

            Console.WriteLine(string.Join(" ", zeros));
            Console.WriteLine(string.Join(" ", ones));
            Console.WriteLine(string.Join(" ", twos));
        }
    }
}