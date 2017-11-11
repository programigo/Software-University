namespace _02.UpperStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> elements =
                Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();


            var elementsToUpper = elements.Select(el => el.ToUpper());

            Console.WriteLine(string.Join(" ", elementsToUpper));
        }
    }
}
