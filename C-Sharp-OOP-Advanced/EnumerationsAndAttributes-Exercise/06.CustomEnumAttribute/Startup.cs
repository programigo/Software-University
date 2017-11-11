namespace _06.CustomEnumAttribute
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string enumType = Console.ReadLine();

            Type type = null;

            if (enumType == "Rank")
            {
                type = typeof(Ranks);
            }
            else
            {
                type = typeof(Suits);
            }

            var attributes = type.GetCustomAttributes(false);

            Console.WriteLine(attributes[0]);
        }
    }
}
