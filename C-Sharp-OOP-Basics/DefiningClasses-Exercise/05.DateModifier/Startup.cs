namespace _05.DateModify
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier date = new DateModifier();

            Console.WriteLine(date.CalculateDifference(firstDate, secondDate));
        }
    }
}