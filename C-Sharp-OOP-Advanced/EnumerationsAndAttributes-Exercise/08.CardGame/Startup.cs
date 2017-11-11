namespace _08.CardGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string firstPlayerName = Console.ReadLine();
            string secondPlayerName = Console.ReadLine();

            List<Card> playerOneCards = new List<Card>();
            List<Card> playerTwoCards = new List<Card>();

            var cardsRanks = Enum.GetNames(typeof(Ranks));
            var cardsSuits = Enum.GetNames(typeof(Suits));

            List<Card> deck = new List<Card>();

            foreach (var cardSuit  in cardsSuits)
            {
                foreach (var cardRank in cardsRanks)
                {
                    Card card = new Card(cardRank, cardSuit);

                    deck.Add(card);
                }
            }

            while (playerOneCards.Count < 5 || playerTwoCards.Count < 5)
            {
                string[] cardInfo = Console.ReadLine().Split();

                try
                {
                    Card currentCard = new Card(cardInfo[0], cardInfo[2]);

                    if (deck.Contains(currentCard))
                    {
                        deck.Remove(currentCard);

                        if (playerOneCards.Count < 5)
                        {
                            playerOneCards.Add(currentCard);
                        }
                        else
                        {
                            playerTwoCards.Add(currentCard);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }

                    
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            var frstPlayerBiggestCard = playerOneCards.OrderByDescending(c => c.GetCardPower()).FirstOrDefault();
            var secondPlayerBiggestCard = playerTwoCards.OrderByDescending(c => c.GetCardPower()).FirstOrDefault();

            if (frstPlayerBiggestCard.GetCardPower() > secondPlayerBiggestCard.GetCardPower())
            {
                Console.WriteLine($"{firstPlayerName} wins with {frstPlayerBiggestCard}.");
            }
            else
            {
                Console.WriteLine($"{secondPlayerName} wins with {secondPlayerBiggestCard}.");
            }
        }
    }
}
