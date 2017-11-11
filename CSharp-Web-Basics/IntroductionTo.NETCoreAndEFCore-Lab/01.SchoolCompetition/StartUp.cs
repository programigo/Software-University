using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SchoolCompetition
{
    public class StartUp
    {
        public static void Main()
        {
            string input;

            Dictionary<string, HashSet<string>> categories = new Dictionary<string, HashSet<string>>();

            Dictionary<string, int> results = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(' ');

                string studentName = inputArgs[0];

                string category = inputArgs[1];

                int points = int.Parse(inputArgs[2]);

                if (!categories.ContainsKey(studentName))
                {
                    categories.Add(studentName, new HashSet<string>());
                }

                categories[studentName].Add(category);

                if (!results.ContainsKey(studentName))
                {
                    results.Add(studentName, points);
                }
                else
                {
                    results[studentName] += points;
                }
            }

            var orderedResults = results.OrderByDescending(p => p.Value).ThenBy(p => p.Key);

            foreach (var student in orderedResults)
            {
                var orderedCategories = categories[student.Key].OrderBy(c => c);

                string listCategories = string.Join(", ", orderedCategories);

                Console.WriteLine($"{student.Key}: {student.Value} [{listCategories}]");
            }
        }
    }
}
