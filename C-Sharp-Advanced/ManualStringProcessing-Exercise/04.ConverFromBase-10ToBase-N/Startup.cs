namespace _04.Base10ToBaseN
{
    using System;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            BigInteger baseNumber = BigInteger.Parse(numbers[0]);
            BigInteger numberToConvert = BigInteger.Parse(numbers[1]);
            string newNumber = String.Empty;

            int index = 0;
            BigInteger remainder;

            while (numberToConvert != 0)
            {
                remainder = numberToConvert % baseNumber;
                numberToConvert = numberToConvert / baseNumber;

                newNumber += remainder;

                index++;
            }

            char[] newNumToChar = newNumber.ToCharArray();
            Array.Reverse(newNumToChar);

            string finalNum = new string(newNumToChar);

            Console.WriteLine(finalNum);
        }
    }
}
