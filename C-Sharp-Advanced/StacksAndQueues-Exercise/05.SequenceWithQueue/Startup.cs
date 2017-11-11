namespace _05.CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();

            queue.Enqueue(n);

            while (queue.Count < 100)
            {
                long currentElement = queue.Peek() + 1;
                queue.Enqueue(currentElement);
                long nextElement = 2 * queue.Peek() + 1;
                queue.Enqueue(nextElement);
                long finalElement = queue.Peek() + 2;
                queue.Enqueue(finalElement);

                Console.Write($"{queue.Dequeue()} ");
            }
        }
    }
}
