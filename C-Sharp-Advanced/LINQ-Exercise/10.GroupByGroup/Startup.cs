namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public class Person
        {
            public Person(string name, int group)
            {
                this.Name = name;
                this.Group = group;
            }

            public string Name { get; set; }

            public int Group { get; set; }
        }

        public static void Main()
        {
            string input = Console.ReadLine();
            List<Person> students = new List<Person>();

            while (input != "END")
            {
                string[] elements = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string studentName = elements[0] + " " + elements[1];
                int groupName = int.Parse(elements[2]);

                Person person = new Person(studentName, groupName);

                students.Add(person);

                input = Console.ReadLine();
            }

            var groupedStudents = students.GroupBy(group => group.Group).OrderBy(gr => gr.Key).ToList();

            foreach (var group in groupedStudents)
            {
                Console.Write($"{group.Key} - ");

                List<string> groupMembers = new List<string>();

                foreach (var person in group)
                {
                    groupMembers.Add(person.Name);
                }

                Console.WriteLine(string.Join(", ", groupMembers));
            }
        }
    }
}