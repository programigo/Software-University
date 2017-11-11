namespace _05.CardCompareTo
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string firstCardRank = Console.ReadLine();
            string firstCardSuit = Console.ReadLine();

            string secondCardRank = Console.ReadLine();
            string secondCardSuit = Console.ReadLine();

            Card firstCard = new Card(firstCardRank, firstCardSuit);

            Card secondCard = new Card(secondCardRank, secondCardSuit);

            if (firstCard.CompareTo(secondCard) > 0)
            {
                Console.WriteLine(firstCard);
            }
            else
            {
                Console.WriteLine(secondCard);
            }
        }
    }
}
