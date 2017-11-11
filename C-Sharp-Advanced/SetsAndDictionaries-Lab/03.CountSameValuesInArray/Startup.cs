namespace _03.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            SortedDictionary<double, int> numberOccurences = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numberOccurences.ContainsKey(number))
                {
                    numberOccurences.Add(number, 1);
                }
                else
                {
                    numberOccurences[number]++;
                }
            }

            foreach (var occurence in numberOccurences)
            {
                Console.WriteLine($"{occurence.Key} - {occurence.Value} times");
            }
        }
    }
}
