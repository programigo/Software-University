namespace _07.ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();

            while (input != "END")
            {
                string[] elements = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string studentName = elements[0] + " " + elements[1];
                List<int> grades = new List<int>();

                for (int i = 2; i < elements.Length; i++)
                {
                    int currentGrade = int.Parse(elements[i]);

                    grades.Add(currentGrade);
                }

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, grades);
                }

                input = Console.ReadLine();
            }

            var validStudents = students.Where(grades => grades.Value.Contains(6));

            foreach (var validStudent in validStudents)
            {
                Console.WriteLine(validStudent.Key);
            }
        }
    }
}