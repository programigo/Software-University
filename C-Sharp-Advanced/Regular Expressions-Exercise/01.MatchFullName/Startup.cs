namespace _01.MatchFullName
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"\b([A-Z][a-z]{2,})+ ([A-Z][a-z]{2,})+\b";
            Regex regex = new Regex(pattern);
            List<string> validNames = new List<string>();

            while (text != "end")
            {
                if (regex.IsMatch(text))
                {
                    validNames.Add(text);
                }

                text = Console.ReadLine();
            }

            foreach (var validName in validNames)
            {
                Console.WriteLine(validName);
            }
        }
    }

}
