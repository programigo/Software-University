namespace _12.CharacterMultiplier
{
    using System;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string firstStr = input[0];
            string secondStr = input[1];

            Multiply(firstStr, secondStr);
        }

        private static void Multiply(string firstStr, string secondStr)
        {
            BigInteger sum = 0;
            int currentPosition = 0;

            for (int i = 0; i < Math.Min(firstStr.Length, secondStr.Length); i++)
            {
                int firstStrLetter = firstStr[i];
                int secondStrLetter = secondStr[i];

                sum += firstStrLetter * secondStrLetter;

                currentPosition++;
            }

            if (firstStr.Length > secondStr.Length)
            {
                for (int i = currentPosition; i < firstStr.Length; i++)
                {
                    int firstStrLetter = firstStr[i];

                    sum += firstStrLetter;
                }
            }
            else if (secondStr.Length > firstStr.Length)
            {
                for (int i = currentPosition; i < secondStr.Length; i++)
                {
                    int secondStrLetter = secondStr[i];

                    sum += secondStrLetter;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
