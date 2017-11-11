namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;

    public class SetsOfElements
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int firstSetLength = int.Parse(input[0]);
            int secondSetLength = int.Parse(input[1]);

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> finalSet = new HashSet<int>();

            for (int i = 0; i < firstSetLength; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                firstSet.Add(currentNumber);
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                secondSet.Add(currentNumber);
            }

            foreach (var firstSetElement in firstSet)
            {
                foreach (var secondSetElement in secondSet)
                {
                    if (firstSetElement == secondSetElement)
                    {
                        finalSet.Add(firstSetElement);
                    }
                }
            }

            foreach (var item in finalSet)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }
    }
}