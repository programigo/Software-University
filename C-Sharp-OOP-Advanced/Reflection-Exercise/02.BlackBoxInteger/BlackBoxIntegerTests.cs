namespace _02BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main(string[] args)
        {
            Type blackBoxType = typeof(BlackBoxInt);

            BlackBoxInt blackBox = (BlackBoxInt)Activator.CreateInstance(blackBoxType, true);

            //ConstructorInfo ci = blackBoxType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[]{}, null);

            string input;
            
            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input.Split('_');

                string methodName = elements[0];
                int value = int.Parse(elements[1]);

                blackBoxType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(blackBox, new object[] {value});

                var field = blackBoxType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First()
                    .GetValue(blackBox);

                Console.WriteLine(field);
            }
        }
    }
}
