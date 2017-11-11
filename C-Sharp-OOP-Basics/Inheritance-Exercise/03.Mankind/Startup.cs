namespace _03.Mankind
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                string[] workerInfo = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);

                Worker worker = new Worker(workerInfo[0], workerInfo[1], double.Parse(workerInfo[2]), double.Parse(workerInfo[3]));

                Console.WriteLine(student);

                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}