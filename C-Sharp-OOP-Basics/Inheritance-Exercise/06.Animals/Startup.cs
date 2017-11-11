namespace _06.Animals
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] animalElements = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string name = animalElements[0];
                    int age = int.Parse(animalElements[1]);
                    string gender = animalElements[2];

                    Animal animal;

                    if (input.ToLower() == "cat")
                    {
                        animal = new Cat(animalElements[0], age, gender);

                        Console.WriteLine(animal);
                    }
                    else if (input.ToLower() == "tomcat")
                    {
                        animal = new Tomcat(name, age, gender);

                        Console.WriteLine(animal);
                    }
                    else if (input.ToLower() == "kitten")
                    {
                        animal = new Kitten(name, age, gender);

                        Console.WriteLine(animal);
                    }
                    else if (input.ToLower() == "dog")
                    {
                        animal = new Dog(name, age, gender);

                        Console.WriteLine(animal);
                    }
                    else if (input.ToLower() == "frog")
                    {
                        animal = new Frog(name, age, gender);

                        Console.WriteLine(animal);
                    }
                    else
                    {
                        animal = new Animal(name, age, gender);
                        Console.WriteLine(animal);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}