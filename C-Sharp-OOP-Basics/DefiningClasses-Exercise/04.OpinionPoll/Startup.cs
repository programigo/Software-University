namespace _04.OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();
                string name = elements[0];
                int age = int.Parse(elements[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            var validPersons = people.Where(person => person.age > 30).OrderBy(person => person.name);

            foreach (var validPerson in validPersons)
            {
                Console.WriteLine($"{validPerson.name} - {validPerson.age}");
            }
        }
    }
}