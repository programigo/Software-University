namespace _08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, HashSet<int>> playersAndHands = new Dictionary<string, HashSet<int>>();

            while (input != "JOKER")
            {
                string[] playerInfo = input.Split(new[] { ' ', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string playerName = playerInfo[0];

                if (!playersAndHands.ContainsKey(playerName))
                {
                    playersAndHands.Add(playerName, new HashSet<int>());
                }

                for (int i = 1; i < playerInfo.Length; i++)
                {
                    string currentCard = playerInfo[i];
                    string cardPower;
                    char cardType;
                    if (currentCard.Length == 3)
                    {
                        cardPower = currentCard[0].ToString() + currentCard[1].ToString();
                        cardType = currentCard[2];
                    }
                    else
                    {
                        cardPower = currentCard[0].ToString();
                        cardType = currentCard[1];
                    }

                    int cardTotalPoints = 0;

                    switch (cardPower)
                    {
                        case "2":
                            cardTotalPoints = 2;
                            break;

                        case "3":
                            cardTotalPoints = 3;
                            break;

                        case "4":
                            cardTotalPoints = 4;
                            break;

                        case "5":
                            cardTotalPoints = 5;
                            break;

                        case "6":
                            cardTotalPoints = 6;
                            break;

                        case "7":
                            cardTotalPoints = 7;
                            break;

                        case "8":
                            cardTotalPoints = 8;
                            break;

                        case "9":
                            cardTotalPoints = 9;
                            break;

                        case "10":
                            cardTotalPoints = 10;
                            break;

                        case "J":
                            cardTotalPoints = 11;
                            break;

                        case "Q":
                            cardTotalPoints = 12;
                            break;

                        case "K":
                            cardTotalPoints = 13;
                            break;

                        case "A":
                            cardTotalPoints = 14;
                            break;
                    }

                    switch (cardType)
                    {
                        case 'S':
                            cardTotalPoints *= 4;
                            break;

                        case 'H':
                            cardTotalPoints *= 3;
                            break;

                        case 'D':
                            cardTotalPoints *= 2;
                            break;

                        case 'C':
                            cardTotalPoints *= 1;
                            break;
                    }

                    playersAndHands[playerName].Add(cardTotalPoints);
                }

                input = Console.ReadLine();
            }

            foreach (var player in playersAndHands)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Sum()}");
            }
        }
    }
}