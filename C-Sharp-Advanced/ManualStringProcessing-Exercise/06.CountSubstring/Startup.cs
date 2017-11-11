namespace _06.CountSubstringOccurrences
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string searchStr = Console.ReadLine().ToLower();
            int counter = 0;

            if (!text.Contains(searchStr))
            {
                counter = 0;
            }
            else
            {
                if (text.Contains(' ') || text.Contains('\t'))
                {
                    for (int currentIndex = 0; currentIndex < text.Length - 2; currentIndex++)
                    {

                        string substrWord = text.Substring(currentIndex, searchStr.Length);

                        if (substrWord == searchStr)
                        {
                            counter++;
                        }
                    }
                }
                else
                {
                    for (int currentIndex = 0; currentIndex < text.Length - 1; currentIndex++)
                    {

                        string substrWord = text.Substring(currentIndex, searchStr.Length);

                        if (substrWord == searchStr)
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
