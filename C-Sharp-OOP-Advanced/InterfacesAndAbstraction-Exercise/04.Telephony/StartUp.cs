namespace _04.Telephony
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();

            IBrowsable smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}