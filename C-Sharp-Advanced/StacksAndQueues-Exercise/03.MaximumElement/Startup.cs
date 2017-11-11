namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] query =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                if (query[0] == 1)
                {
                    int elementToPush = query[1];

                    stack.Push(elementToPush);
                }
                else if (query[0] == 2)
                {
                    stack.Pop();
                }
                else if (query[0] == 3)
                {
                    Console.WriteLine(stack.Max());
                }
            }
        }
    }
}
