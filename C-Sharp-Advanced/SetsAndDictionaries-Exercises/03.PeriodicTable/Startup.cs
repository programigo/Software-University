namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] currentElements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < currentElements.Length; j++)
                {
                    string element = currentElements[j];

                    uniqueElements.Add(element);
                }
            }

            foreach (var uniqueElement in uniqueElements)
            {
                Console.Write($"{uniqueElement} ");
            }

            Console.WriteLine();
        }
    }
}