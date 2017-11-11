namespace _04.SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] text = Console.ReadLine()
                .Split(new[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> occurences = new Dictionary<string, int>();

            for (int i = 0; i < list.Count; i++)
            {
                string currentWord = list[i];

                for (int j = 0; j < text.Length; j++)
                {
                    string currentTextWord = text[j];

                    if (currentWord.ToLower() == currentTextWord.ToLower())
                    {
                        if (!occurences.ContainsKey(currentWord))
                        {
                            occurences.Add(currentWord, 1);
                        }
                        else
                        {
                            occurences[currentWord]++;
                        }
                    }
                    else
                    {
                        if (!occurences.ContainsKey(currentWord))
                        {
                            occurences.Add(currentWord, 0);
                        }
                    }
                }
            }

            foreach (var occurence in occurences)
            {
                Console.WriteLine($"{occurence.Key} - {occurence.Value}");
            }
        }
    }
}