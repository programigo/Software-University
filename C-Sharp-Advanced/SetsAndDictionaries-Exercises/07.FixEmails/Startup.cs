namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, string> people = new Dictionary<string, string>();

            int currentLine = 1;

            string name = String.Empty;

            while (input != "stop")
            {
                if (currentLine % 2 != 0)
                {
                    name = input;

                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, String.Empty);
                    }
                }
                else
                {
                    string email = input;

                    people[name] = email;
                }

                currentLine++;
                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (!person.Value.EndsWith("us") && !person.Value.EndsWith("uk"))
                {
                    Console.WriteLine($"{person.Key} -> {person.Value}");
                }
            }
        }
    }
}