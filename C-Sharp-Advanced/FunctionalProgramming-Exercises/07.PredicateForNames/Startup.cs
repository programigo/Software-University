namespace _07.PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            names.RemoveAll(name => name.Length > length);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}