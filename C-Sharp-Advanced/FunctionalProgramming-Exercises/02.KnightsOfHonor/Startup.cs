namespace _02.KnightsOfHonor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> names =
                Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
