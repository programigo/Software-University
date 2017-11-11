namespace _02.MatchPhoneNumber
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\+[359]+(\-|\s)(2)\1(\d{3})\1(\d{4})\b";
            Regex regex = new Regex(pattern);
            List<string> validNumbers = new List<string>();

            while (input != "end")
            {
                if (regex.IsMatch(input))
                {
                    validNumbers.Add(input);
                }

                input = Console.ReadLine();
            }

            foreach (var validNumber in validNumbers)
            {
                Console.WriteLine(validNumber);
            }
        }
    }

}
