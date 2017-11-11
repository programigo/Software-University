namespace _01.EvenNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class EvenNumbersThread
    {
        public static void Main()
        {
            var range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];

            Thread evens = new Thread(() => PrinEvenNumbers(start, end));

            evens.Start();
            evens.Join();

            Console.WriteLine("Thread finished work");
        }

        private static void PrinEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
