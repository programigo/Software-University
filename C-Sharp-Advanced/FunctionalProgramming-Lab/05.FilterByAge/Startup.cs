namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, age);
                }
            }

            string condition = Console.ReadLine();
            int personAge = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<KeyValuePair<string, int>> validPersons = new KeyValuePair<string, int>[people.Count];

            if (condition == "younger")
            {
                validPersons = people.Where(age => age.Value < personAge);
            }
            else if (condition == "older")
            {
                validPersons = people.Where(age => age.Value >= personAge);
            }

            if (command.Length == 1)
            {
                if (command[0] == "name")
                {
                    foreach (var person in validPersons)
                    {
                        Console.WriteLine($"{person.Key}");
                    }
                }
                else if (command[0] == "age")
                {
                    foreach (var person in validPersons)
                    {
                        Console.WriteLine($"{person.Value}");
                    }
                }
            }
            else
            {
                foreach (var person in validPersons)
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }
            }
        }
    }
}

