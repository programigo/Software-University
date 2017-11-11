namespace _07.DeckOfCards
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var ranks = Enum.GetValues(typeof(Ranks));
            var suits = Enum.GetValues(typeof(Suits));

            foreach (var rank in ranks)
            {
                foreach (var suit in suits)
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}
