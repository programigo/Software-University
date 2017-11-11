namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedSet<string> parking = new SortedSet<string>();

            while (input != "END")
            {
                string[] elements = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = elements[0];

                if (command == "IN")
                {
                    parking.Add(elements[1]);
                }
                else
                {
                    parking.Remove(elements[1]);
                }

                input = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
