namespace _05.SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            if (command.ToLower() == "slice")
            {
                string sourceFile = Console.ReadLine();
                string destinationDirectory = Console.ReadLine();
                int parts = int.Parse(Console.ReadLine());

                Slice(sourceFile, destinationDirectory, parts);
            }
            else if (command.ToLower() == "assemble")
            {
                List<string> files = new List<string>();
                string destinationDirectory = Console.ReadLine();

                Assembe(files, destinationDirectory);
            }
        }

        private static void Assembe(List<string> files, string destinationDirectory)
        {
            string[] tempFiles = Directory.GetFiles(destinationDirectory, "*.mp4");

            FileStream outputFile = null;
            string previousFileName = String.Empty;

            foreach (var tempFile in tempFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(tempFile);

                if (!previousFileName.Equals(fileName))
                {
                    if (outputFile != null)
                    {
                        outputFile.Flush();
                        outputFile.Close();
                    }
                    outputFile = new FileStream(destinationDirectory + "\\" + fileName, FileMode.OpenOrCreate, FileAccess.Write);
                }

                int bytesRead = 0;
                byte[] buffer = new byte[1024];

                FileStream inputTempFile = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Read);

                while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                {
                    outputFile.Write(buffer, 0, bytesRead);
                }

                inputTempFile.Close();
                File.Delete(tempFile);
                previousFileName = fileName;
            }
            outputFile.Close();
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            {
                int sizeOfEachFile = (int)Math.Ceiling((double)fs.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    string baseFileName = $"Part-{i}";
                    string extension = Path.GetExtension(sourceFile);

                    FileStream outputFile = new FileStream(
                        destinationDirectory + "\\" + baseFileName + extension, FileMode.Create, FileAccess.Write);

                    int bytesRead = 0;
                    byte[] buffer = new byte[sizeOfEachFile];

                    if ((bytesRead = fs.Read(buffer, 0, sizeOfEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);
                    }

                    outputFile.Close();
                }
            }
        }
    }
}