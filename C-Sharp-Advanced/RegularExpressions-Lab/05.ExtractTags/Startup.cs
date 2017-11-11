namespace _05.ExtractTags
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"<.+?>";

            Regex regex = new Regex(pattern);

            while (text != "END")
            {
                MatchCollection matches = regex.Matches(text);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }

                text = Console.ReadLine();
            }
        }
    }
}
