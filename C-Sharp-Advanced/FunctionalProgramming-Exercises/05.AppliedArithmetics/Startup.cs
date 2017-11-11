namespace _05.AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = ChangeNumbers(numbers, num => num + 1);
                        break;
                    case "multiply":
                        numbers = ChangeNumbers(numbers, num => num * 2);
                        break;
                    case "subtract":
                        numbers = ChangeNumbers(numbers, num => num - 1);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }

        public static List<int> ChangeNumbers(List<int> numbers, Func<int, int> func)
        {
            List<int> result = new List<int>();
            foreach (var number in numbers)
            {
                result.Add(func(number));
            }
            return result;
        }
    }
}
