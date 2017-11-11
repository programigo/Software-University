namespace _04.AddVat
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            double[] numbers =
                Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

            var collection = numbers.Select(num => num += num * 0.20);

            foreach (var item in collection)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}

