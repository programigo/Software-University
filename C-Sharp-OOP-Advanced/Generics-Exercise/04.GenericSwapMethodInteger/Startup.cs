namespace _04.GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            IList<Box<int>> elements = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(element);

                elements.Add(box);
            }

            var cmdArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapElements(elements, cmdArgs[0], cmdArgs[1]);

            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        public static void SwapElements<T>(IList<T> elements, int firstIndex, int secondIndex)
        {
            T temporaryValue = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temporaryValue;
        }
    }
}