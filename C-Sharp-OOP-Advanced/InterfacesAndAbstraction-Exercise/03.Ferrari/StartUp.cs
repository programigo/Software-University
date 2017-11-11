namespace _03.Ferrari
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            bool isCreated = typeof(ICar).IsInterface;

            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

            string driver = Console.ReadLine();

            ICar ferrari = new global::Ferrari(driver);

            Console.WriteLine(ferrari);
        }
    }
}