namespace _01.ActionPrint
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] names = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
