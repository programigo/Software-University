namespace _09.StudentsEnrolled
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
                string facultyNumber = elements[0];
                List<int> grades = new List<int>();

                for (int i = 1; i < elements.Length; i++)
                {
                    int currentGrade = int.Parse(elements[i]);

                    grades.Add(currentGrade);
                }

                if (!students.ContainsKey(facultyNumber))
                {
                    students.Add(facultyNumber, grades);
                }

                input = Console.ReadLine();
            }

            var validStudents =
                students.Where(facultyNum => facultyNum.Key.EndsWith("14") || facultyNum.Key.EndsWith("15"));

            foreach (var validStudent in validStudents)
            {
                Console.WriteLine(string.Join(" ", validStudent.Value));
            }
        }
    }
}