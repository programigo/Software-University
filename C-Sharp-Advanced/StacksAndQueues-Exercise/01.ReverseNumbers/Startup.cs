namespace _01.ReverseNumbersWithAStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                stack.Push(numbers[i]);

                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
