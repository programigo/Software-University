namespace _01.StudentsResults
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string name;
        private double caDV;
        private double cOOP;
        private double advOOP;

        public Student(string name, double caDv, double coop, double advOop)
        {
            Name = name;
            CaDV = caDv;
            Coop = coop;
            AdvOOP = advOop;
        }

        public string Name { get; set; }

        public double CaDV { get; set; }

        public double Coop { get; set; }

        public double AdvOOP { get; set; }
    }

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(new[] { '-', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentInfo[0];
                double caDV = double.Parse(studentInfo[1]);
                double cOOP = double.Parse(studentInfo[2]);
                double advOOP = double.Parse(studentInfo[3]);

                Student student = new Student(studentName, caDV, cOOP, advOOP);

                students.Add(student);
            }

            Console.WriteLine("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");

            foreach (var student in students)
            {
                Console.WriteLine("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", student.Name, student.CaDV,
                    student.Coop, student.AdvOOP, (student.CaDV + student.Coop + student.AdvOOP) / 3);
            }
        }
    }
}