namespace _04.FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] input =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int lowerBound = input[0];
            int upperBound = input[1];
            string command = Console.ReadLine();

            List<int> numbres = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbres.Add(i);
            }

            if (command == "odd")
            {
                var oddNumbers = numbres.Where(num => num % 2 != 0);

                Console.WriteLine(string.Join(" ", oddNumbers));
            }
            else
            {
                var evenNumbers = numbres.Where(num => num % 2 == 0);

                Console.WriteLine(string.Join(" ", evenNumbers));
            }
        }
    }
}
