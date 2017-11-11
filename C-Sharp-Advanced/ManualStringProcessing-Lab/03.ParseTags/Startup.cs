namespace _03.ParseTags
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string openingUpper = "<upcase>";
            string closingUpper = "</upcase>";
            StringBuilder wordToUpper = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int startIndex = text.IndexOf(openingUpper);
                int endingIndex = text.IndexOf(closingUpper);

                if (startIndex < 0 || endingIndex < 0)
                {
                    break;
                }

                for (int j = startIndex + openingUpper.Length; j < endingIndex; j++)
                {
                    wordToUpper.Append(text[j]);
                }
                string wordToReplace = wordToUpper.ToString();
                text = text.Replace(wordToReplace, wordToReplace.ToUpper());
                text = text.Remove(endingIndex, closingUpper.Length);
                text = text.Remove(startIndex, openingUpper.Length);

                wordToUpper = new StringBuilder();
            }

            Console.WriteLine(text);
        }
    }
}