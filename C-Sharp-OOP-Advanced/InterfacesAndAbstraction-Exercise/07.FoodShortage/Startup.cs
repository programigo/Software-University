using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    public class Startup
    {
        public static void Main()
        {
            string input;

            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var buyerInfo = Console.ReadLine().Split();

                IBuyer buyer = null;

                if (buyerInfo.Length == 4)
                {
                    buyer = new Citizen(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2], buyerInfo[3]);
                }
                else
                {
                    buyer = new Rebel(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2]);
                }

                buyer.BuyFood();

                buyers.Add(buyer);
            }

            int totalFood = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                IBuyer currentBuyer = buyers.FirstOrDefault(b => b.Name == input);

                if (buyers.Contains(currentBuyer))
                {
                    totalFood += currentBuyer.Food;
                }
            }

            Console.WriteLine(totalFood);
        }
    }
}