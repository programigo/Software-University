namespace _08.FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        private static StringCollection log = new StringCollection();

        public static void Main()
        {
            string folderPath = Console.ReadLine();

            DirectoryInfo di = new DirectoryInfo(folderPath);

            WalkDirectoryTree(di);
        }

        private static void WalkDirectoryTree(DirectoryInfo root)
        {
            StreamWriter result = new StreamWriter("report.txt");
            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (result)
            {
                FileInfo[] files = null;
                DirectoryInfo[] subDirs = null;
                Dictionary<string, SortedDictionary<string, double>> allFiles = new Dictionary<string, SortedDictionary<string, double>>();

                try
                {
                    files = root.GetFiles();
                }
                catch (UnauthorizedAccessException e)
                {
                    log.Add(e.Message);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                if (files != null)
                {
                    foreach (var fileInfo in files)
                    {
                        string fileName = fileInfo.Name;
                        string fileExtension = fileInfo.Extension;
                        var size = fileInfo.Length / 1024;

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

                    subDirs = root.GetDirectories();

                    foreach (var directoryInfo in subDirs)
                    {
                        WalkDirectoryTree(directoryInfo);
                    }

                    var sorted = allFiles.OrderByDescending(file => file.Value.Count);

                    foreach (var extension in sorted)
                    {
                        Console.WriteLine(extension.Key);

                        var orderedFiles = extension.Value.OrderByDescending(size => size.Value);

                        foreach (var file in orderedFiles)
                        {
                            result.WriteLine($"--{file.Key} - {file.Value}kb");
                        }
                    }
                }
            }
        }
    }
}