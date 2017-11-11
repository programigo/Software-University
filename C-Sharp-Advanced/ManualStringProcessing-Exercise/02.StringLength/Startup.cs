namespace _02.StringLength
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder finalText = new StringBuilder();

            if (text.Length >= 20)
            {
                finalText.Append(text.Substring(0, 20));
            }
            else
            {
                finalText.Append(text).Append('*', 20 - text.Length);
            }

            Console.WriteLine(finalText);
        }
    }
}
