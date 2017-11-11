namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            StreamReader wordsRead = new StreamReader("../../words.txt");
            StreamReader textRead = new StreamReader("../../text.txt");
            StreamWriter result = new StreamWriter("../../result.txt");

            using (wordsRead)
            {
                using (textRead)
                {
                    using (result)
                    {
                        string wordsLine = wordsRead.ReadLine();
                        string textLine = textRead.ReadLine();
                        Dictionary<string, int> words = new Dictionary<string, int>();

                        while (wordsLine != null)
                        {
                            while (textLine != null)
                            {
                                string[] lineWords = Regex.Split(textLine, "\\W+");

                                for (int i = 0; i < lineWords.Length; i++)
                                {
                                    string currentWord = lineWords[i].ToLower();

                                    if (String.Equals(currentWord, wordsLine, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        if (!words.ContainsKey(currentWord))
                                        {
                                            words.Add(currentWord, 1);
                                        }
                                        else
                                        {
                                            words[currentWord]++;
                                        }
                                    }
                                }

                                textLine = textRead.ReadLine();
                            }

                            textRead = new StreamReader("../../text.txt");
                            textLine = textRead.ReadLine();
                            wordsLine = wordsRead.ReadLine();
                        }

                        var sortedWords = words.OrderByDescending(frequency => frequency.Value);

                        foreach (var word in sortedWords)
                        {
                            result.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}