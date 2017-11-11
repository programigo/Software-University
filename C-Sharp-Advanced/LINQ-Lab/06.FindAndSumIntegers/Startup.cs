namespace _06.FindAndSumIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> elements =
                Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<long> allInts = new List<long>();

            foreach (var element in elements)
            {
                long num;

                if (long.TryParse(element, out num))
                {
                    allInts.Add(num);
                }
            }

            if (allInts.Count == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(allInts.Sum());
            }
        }
    }
}
