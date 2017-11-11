namespace _03.FormattingNumbers
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int intNumber = int.Parse(input[0]);
            decimal fistFloat = decimal.Parse(input[1]);
            decimal secondFloat = decimal.Parse(input[2]);

            var intToHexa = $"{intNumber:X}";
            string intToBinary = Convert.ToString(intNumber, 2).PadLeft(10, '0').Substring(0, 10);

            Console.WriteLine($"|{intToHexa,-10}|{intToBinary}|{fistFloat,10:f2}|{secondFloat,-10:f3}|");
        }
    }
}
