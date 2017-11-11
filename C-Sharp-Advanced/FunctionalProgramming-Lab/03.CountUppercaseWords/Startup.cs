namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var words = input.Where(word => Char.IsUpper(word[0]));

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
