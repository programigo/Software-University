namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, int>> logs = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] currentLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string ip = currentLine[0];
                string user = currentLine[1];
                int duration = int.Parse(currentLine[2]);

                if (!logs.ContainsKey(user))
                {
                    logs.Add(user, new SortedDictionary<string, int>());
                }

                if (!logs[user].ContainsKey(ip))
                {
                    logs[user].Add(ip, duration);
                }
                else
                {
                    logs[user][ip] += duration;
                }
            }

            foreach (var log in logs)
            {
                List<string> currentIps = new List<string>();

                Console.Write($"{log.Key}: {log.Value.Values.Sum()} ");

                foreach (var currentLog in log.Value)
                {
                    string ip = currentLog.Key;

                    currentIps.Add(ip);
                }

                Console.Write($"[{string.Join(", ", currentIps)}]");

                Console.WriteLine();
            }
        }
    }
}