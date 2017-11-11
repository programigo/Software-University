namespace _05.BaseNToBase10
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            BigInteger[] input =
                Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();

            BigInteger baseNum = input[0];
            BigInteger numToConvert = input[1];

            string number = numToConvert.ToString();
            BigInteger n = 1;
            BigInteger r = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                r += n * (number[i] - '0');
                n *= baseNum;
            }

            Console.WriteLine(r);
        }
    }
}
