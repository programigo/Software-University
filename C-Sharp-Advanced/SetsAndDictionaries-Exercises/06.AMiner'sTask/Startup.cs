namespace _06.AMinerTask
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, int> resources = new Dictionary<string, int>();

            int currentLine = 1;

            string resource = String.Empty;

            while (input != "Stop".ToLower())
            {
                if (currentLine % 2 != 0)
                {
                    resource = input;

                    if (!resources.ContainsKey(resource))
                    {
                        resources.Add(resource, 0);
                    }
                }
                else
                {
                    int quantity = int.Parse(input);

                    resources[resource] += quantity;
                }

                currentLine++;
                input = Console.ReadLine();
            }

            foreach (var element in resources)
            {
                Console.WriteLine($"{element.Key} -> {element.Value}");
            }
        }
    }
}