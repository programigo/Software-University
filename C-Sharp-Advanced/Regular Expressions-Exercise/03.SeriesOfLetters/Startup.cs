namespace _03.SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"(.)\1+";

            Regex regex = new Regex(pattern);
            string result = regex.Replace(text, "$1");

            Console.WriteLine(result);
        }
    }

}
