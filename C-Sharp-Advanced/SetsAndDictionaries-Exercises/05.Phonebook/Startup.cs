namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, string> contacts = new Dictionary<string, string>();

            while (input != "search")
            {
                string[] contactElements = input.Split('-');

                if (contactElements.Length == 2)
                {
                    string contactName = contactElements[0];
                    string contactNumber = contactElements[1];

                    if (!contacts.ContainsKey(contactName))
                    {
                        contacts.Add(contactName, contactNumber);
                    }
                    else
                    {
                        contacts[contactName] = contactNumber;
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                if (contacts.ContainsKey(input))
                {
                    var phoneNumber = contacts[input];

                    Console.WriteLine($"{input} -> {phoneNumber}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}