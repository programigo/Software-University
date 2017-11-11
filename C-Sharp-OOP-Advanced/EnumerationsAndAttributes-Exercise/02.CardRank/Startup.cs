using System;

namespace _02.CardRank
{
    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            string command = input[1];

            Console.WriteLine($"Card {command}:");

            if (command == "Suits")
            {              
                var suits = Enum.GetValues(typeof(Suits));

                foreach (var suit in suits)
                {
                    Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
                }
            }
            else
            {
                var ranks = Enum.GetValues(typeof(Ranks));

                foreach (var rank in ranks)
                {
                    Console.WriteLine($"Ordinal value: {(int) rank}; Name value: {rank}");
                }
            }
        }
    }
}
