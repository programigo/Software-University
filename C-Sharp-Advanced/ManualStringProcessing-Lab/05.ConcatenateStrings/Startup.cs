namespace _05.ConcatenateStrings
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string currentLine = Console.ReadLine();

                sb.Append(currentLine).Append(" ");
            }

            Console.WriteLine(sb);
        }
    }
}