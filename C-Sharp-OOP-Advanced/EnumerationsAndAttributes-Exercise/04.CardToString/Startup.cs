namespace _04.CardToString
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string rankPower = Console.ReadLine();

            string suitPower = Console.ReadLine();

            Card card = new Card(rankPower, suitPower);

            Console.WriteLine(card);
        }
    }
}
