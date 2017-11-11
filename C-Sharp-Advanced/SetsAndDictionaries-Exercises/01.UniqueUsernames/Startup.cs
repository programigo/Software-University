namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            HashSet<string> set = new HashSet<string>();

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string currentName = Console.ReadLine();

                set.Add(currentName);
            }

            Console.WriteLine();

            foreach (var username in set)
            {
                Console.WriteLine(username);
            }
        }
    }
}