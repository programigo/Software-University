namespace _01.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string[]> allStudents = new List<string[]>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] studentInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                allStudents.Add(studentInfo);

                input = Console.ReadLine();
            }

            var validStudents = allStudents.Where(group => group[2] == "2").OrderBy(name => name[0]);

            foreach (var validStudent in validStudents)
            {
                Console.WriteLine(validStudent[0] + " " + validStudent[1]);
            }
        }
    }
}