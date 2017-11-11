namespace _01.OddLines
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("../../somefile.txt");
            using (reader)
            {
                int currentLine = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    currentLine++;
                    if (currentLine % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}