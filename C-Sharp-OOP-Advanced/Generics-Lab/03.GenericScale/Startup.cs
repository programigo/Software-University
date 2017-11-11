namespace _03.GenericScale
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Scale<string> scale = new Scale<string>("6", "6");

            Console.WriteLine(scale.GetHavier());
        }
    }
}
