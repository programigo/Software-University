namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();

            stack.Push(0);

            long firstSumNumber = stack.Peek();

            stack.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                long sumedNumber = firstSumNumber + stack.Peek();
                firstSumNumber = stack.Pop();
                stack.Push(sumedNumber);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
