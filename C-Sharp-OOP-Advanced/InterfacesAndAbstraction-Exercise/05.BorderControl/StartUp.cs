namespace _05.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input;

            List<IBeing> allBeings = new List<IBeing>();

            while ((input = Console.ReadLine()) != "End")
            {
                var beingInfo = input.Split();

                IBeing being = null;

                if (beingInfo.Length > 2)
                {
                    being = new Citizen(beingInfo[0], int.Parse(beingInfo[1]), beingInfo[2]);
                }
                else
                {
                    being = new Robot(beingInfo[0], beingInfo[1]);
                }

                allBeings.Add(being);
            }

            string lastDigits = Console.ReadLine();

            var fakes = allBeings.Where(b => b.Id.EndsWith(lastDigits)).ToList();

            fakes.ForEach(b => Console.WriteLine(b.Id));
        }
    }
}