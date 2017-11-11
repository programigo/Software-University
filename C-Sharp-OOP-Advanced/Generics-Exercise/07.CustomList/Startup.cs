namespace _07.CustomList
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input;

            DataStructure<string> customList = new DataStructure<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input.Split();
                string command = elements[0];

                switch (command)
                {
                    case "Add":
                        customList.Add(elements[1]);
                        break;

                    case "Remove":
                        customList.Remove(int.Parse(elements[1]));
                        break;

                    case "Contains":
                        Console.WriteLine(customList.Contains(elements[1]));
                        break;

                    case "Swap":
                        customList.Swap(int.Parse(elements[1]), int.Parse(elements[2]));
                        break;

                    case "Greater":
                        Console.WriteLine(customList.CountGreaterThan(elements[1]));
                        break;

                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;

                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;

                    case "Print":
                        foreach (var item in customList)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }
            }
        }
    }
}