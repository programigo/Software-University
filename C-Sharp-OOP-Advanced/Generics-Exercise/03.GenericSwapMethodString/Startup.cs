namespace _03.GenericSwapMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            IList<Box<string>> elements = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();

                Box<string> box = new Box<string>(element);

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