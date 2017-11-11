namespace _09.TextFilter
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string[] bannedWords = Console.ReadLine()
                .Split(new[] { ' ', ',', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder(text);

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string currentWord = bannedWords[i];

                if (sb.ToString().Contains(currentWord))
                {
                    sb.Replace(currentWord, new string('*', currentWord.Length));
                }
            }

            Console.WriteLine(sb);
        }
    }
}
