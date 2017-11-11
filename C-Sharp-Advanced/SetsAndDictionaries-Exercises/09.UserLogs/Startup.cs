namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, int>> userLogs = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var elements = Regex.Split(input, "=|\\s+");

                string ip = elements[1];
                string user = elements[5];

                if (!userLogs.ContainsKey(user))
                {
                    userLogs.Add(user, new Dictionary<string, int>());
                }

                if (!userLogs[user].ContainsKey(ip))
                {
                    userLogs[user].Add(ip, 1);
                }
                else
                {
                    userLogs[user][ip]++;
                }

                input = Console.ReadLine();
            }

            foreach (var userLog in userLogs)
            {
                List<string> logs = new List<string>();

                Console.WriteLine($"{userLog.Key}:");

                foreach (var log in userLog.Value)
                {
                    string currentLine = $"{log.Key} => {log.Value}";

                    logs.Add(currentLine);
                }

                Console.Write(string.Join(", ", logs));
                Console.WriteLine(".");
            }
        }
    }
}