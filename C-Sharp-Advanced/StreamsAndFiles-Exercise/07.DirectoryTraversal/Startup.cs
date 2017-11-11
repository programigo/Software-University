namespace _07.DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string folderPath = Console.ReadLine();

            Dictionary<string, SortedDictionary<string, double>> allFiles = new Dictionary<string, SortedDictionary<string, double>>();

            DirectoryInfo di = new DirectoryInfo(folderPath);

            FileInfo[] files = di.GetFiles();

            foreach (var file in files)
            {
                string fileName = file.Name;
                string fileExtension = file.Extension;
                var size = file.Length / 1024;

                if (!allFiles.ContainsKey(fileExtension))
                {
                    allFiles.Add(fileExtension, new SortedDictionary<string, double>());
                }

                if (!allFiles[fileExtension].ContainsKey(fileName))
                {
                    allFiles[fileExtension].Add(fileName, size);
                }
                allFiles[fileExtension][fileName]++;
            }

            var sorted = allFiles.OrderByDescending(file => file.Value.Count);

            foreach (var extension in sorted)
            {
                Console.WriteLine(extension.Key);

                var orderedFiles = extension.Value.OrderByDescending(size => size.Value);

                foreach (var file in orderedFiles)
                {
                    Console.WriteLine($"--{file.Key} - {file.Value}kb");
                }
            }
        }
    }
}