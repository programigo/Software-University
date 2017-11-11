namespace _14.LettersChangeNumbers
{
    using System;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string currentSequence = input[i];


                char firstLetter = currentSequence[0];
                decimal number = decimal.Parse(currentSequence.Substring(currentSequence.IndexOf(firstLetter) + 1,
                    currentSequence.Length - 2));
                char secondLetter = currentSequence[currentSequence.Length - 1];

                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    number /= firstLetter - 64;
                }
                else if (firstLetter >= 97 && firstLetter <= 122)
                {
                    number *= firstLetter - 96;
                }

                if (secondLetter >= 65 && secondLetter <= 90)
                {
                    number -= secondLetter - 64;
                }
                else if (secondLetter >= 97 && secondLetter <= 122)
                {
                    number += secondLetter - 96;
                }

                sum += number;

            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
