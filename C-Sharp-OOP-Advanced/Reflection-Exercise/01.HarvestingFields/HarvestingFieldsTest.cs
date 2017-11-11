namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input;

            Type harvesType = typeof(HarvestingFields);

            FieldInfo[] allFields =
                harvesType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                if (input == "private")
                {
                    foreach (var field in allFields.Where(f => f.IsPrivate))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (input == "protected")
                {
                    foreach (var field in allFields.Where(f => f.IsFamily))
                    {
                        Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (input == "public")
                {
                    foreach (var field in allFields.Where(f => f.IsPublic))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (input == "all")
                {
                    foreach (var field in allFields)
                    {
                        if (field.Attributes.ToString().ToLower() != "family")
                        {
                            Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                    }
                }
            }
        }
    }
}
