namespace _04.SortStudents
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
                string[] studentInfo = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                allStudents.Add(studentInfo);

                input = Console.ReadLine();
            }

            var sortedStudents = allStudents.OrderBy(name => name[1]).ThenByDescending(name => name[0]);

            foreach (var validStudent in sortedStudents)
            {
                Console.WriteLine(validStudent[0] + " " + validStudent[1]);
            }
        }
    }
}