namespace _07.ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"[01][0-9]:[0-5][0-9]:[0-5][0-9] [A|P]M";

            Regex regex = new Regex(pattern);

            while (input != "END")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}