namespace _04.Collector
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string result = spy.CollectGettersAndSetters("Hacker");

            Console.WriteLine(result);
        }
    }
}
