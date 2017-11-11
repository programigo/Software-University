namespace _02.LineNumbers
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            string readFilePath = Console.ReadLine();
            string writeFilePath = Console.ReadLine();

            StreamReader reader = new StreamReader(readFilePath);
            StreamWriter writer = new StreamWriter(writeFilePath);

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    int currentLineNumber = 0;

                    while (line != null)
                    {
                        currentLineNumber++;

                        writer.WriteLine($"{currentLineNumber} {line}");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}