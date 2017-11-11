namespace _11.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> palindromes = new List<string>();

            StringBuilder firstHalf = new StringBuilder();
            StringBuilder secondHalf = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];

                if (currentWord.Length == 1)
                {
                    palindromes.Add(currentWord);
                }
                else if (currentWord.Length == 2)
                {
                    if (currentWord[0] == currentWord[1])
                    {
                        palindromes.Add(currentWord);
                    }
                }
                else
                {
                    if (currentWord.Length % 2 != 0)
                    {
                        for (int j = 0; j < currentWord.Length / 2 + 1; j++)
                        {
                            firstHalf.Append(currentWord[j]);
                        }

                        for (int k = currentWord.Length / 2; k < currentWord.Length; k++)
                        {
                            secondHalf.Insert(0, currentWord[k]);
                        }

                        if (firstHalf.ToString() == secondHalf.ToString())
                        {
                            palindromes.Add(currentWord);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < currentWord.Length / 2; j++)
                        {
                            firstHalf.Append(currentWord[j]);
                        }

                        for (int k = currentWord.Length / 2; k < currentWord.Length; k++)
                        {
                            secondHalf.Insert(0, currentWord[k]);
                        }

                        if (firstHalf.ToString() == secondHalf.ToString())
                        {
                            palindromes.Add(currentWord);
                        }
                    }

                    firstHalf = new StringBuilder();
                    secondHalf = new StringBuilder();
                }
            }

            var sorted = palindromes.OrderBy(name => name);

            Console.Write("[");
            Console.Write(string.Join(", ", sorted));
            Console.WriteLine("]");
        }
    }
}
