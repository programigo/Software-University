namespace _15.MelrahShake
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int startIndex = input.IndexOf(pattern);
                int lastIndex = input.LastIndexOf(pattern);

                if (startIndex == -1 || startIndex == lastIndex)
                {
                    break;
                }

                input = input.Remove(lastIndex, pattern.Length);
                input = input.Remove(startIndex, pattern.Length);

                Console.WriteLine("Shaked it.");

                if (pattern.Length <= 1)
                {
                    break;
                }

                pattern = pattern.Remove(pattern.Length / 2, 1);
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(input);
        }
    }
}