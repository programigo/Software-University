namespace _10.UnicodeCharacters
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToCharArray();

            StringBuilder sb = new StringBuilder();

            foreach (var letter in text)
            {
                string escape = "\\u" + ((int)letter).ToString("X").PadLeft(4, '0').ToLower();
                sb.Append(escape);
            }

            Console.WriteLine(sb);
        }
    }
}
