namespace _03.StudentsByAge
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

            var validStudents = allStudents.Where(age => int.Parse(age[2]) >= 18 && int.Parse(age[2]) <= 24);

            foreach (var validStudent in validStudents)
            {
                Console.WriteLine(validStudent[0] + " " + validStudent[1] + " " + validStudent[2]);
            }
        }
    }
}
