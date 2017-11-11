namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> occurences = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                if (!occurences.ContainsKey(currentSymbol))
                {
                    occurences.Add(currentSymbol, 1);
                }
                else
                {
                    occurences[currentSymbol]++;
                }
            }

            foreach (var digit in occurences)
            {
                Console.WriteLine($"{digit.Key}: {digit.Value} time/s");
            }
        }
    }
}